# AirTrafficMonitor

Pushing to master now requires a code review by 1 other member of the team. Please use feature branches.

## How to add a Jenkins test job

1. Make a new job: http://ci3.ase.au.dk:8080/view/all/newJob
2. Give the job a name and choose a template. We used the TemplateBuildTest template given from the SWT course.
3. In `Configure` set the project URL to https://github.com/grottrup/AirTrafficMonitor
4. In `Configure` make the Jenkinsfile pipeline script like so:


``` Jenkinsfile
node('master'){
    stage('Fetch from Git'){
        git url:'https://github.com/grottrup/AirTrafficMonitor'
    }
    
    stage('Update NuGet packages')    {
        bat '"C:\\Program Files (x86)\\NuGet\\nuget" restore Source\\AirTrafficMonitor\\AirTrafficMonitor.sln'
    }
    
    stage('Build'){
    
        bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\BuildTools\\MSBuild\\15.0\\Bin\\MSBuild.exe" Source\\AirTrafficMonitor\\AirTrafficMonitor.sln'
    }
    
    try {
        stage('Run coverage of unit tests') {
            bat '"C:\\Program Files (x86)\\Jetbrains\\JetBrains.dotCover.CommandLineTools.2017.2.2\\dotCover.exe" analyze Source\\AirTrafficMonitor\\dotCoverCoverageConfig.xml'
        }
    }
    finally {
        stage('Publish Test Results') {
            nunit testResultsPattern: 'Source\\AirTrafficMonitor\\AirTrafficMonitor.Tests\\TestResult.xml'

        }
    }
     // Only publish coverage if all tests passed
    stage('Publish Coverage Results') {
        publishHTML([allowMissing: false, alwaysLinkToLastBuild: true, keepAll: false, reportDir: '.', reportFiles: 'Source\\AirTrafficMonitor\\coverage_report.html', reportName: 'Coverage Report', reportTitles: ''])
    }
    
}


```

5. Add a GitHub Web Hook in GitHub Settings with the following address: `http://ci3.ase.au.dk:8080/github-webhook/`
