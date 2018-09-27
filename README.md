# AirTrafficMonitor

## How to add a Jenkins job

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
        bat '"C:\\Program Files (x86)\\NuGet\\nuget" restore AirTrafficMonitor.sln'
    }
    
    stage('Build'){
    
        bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\BuildTools\\MSBuild\\15.0\\Bin\\MSBuild.exe" AirTrafficMonitor.sln'
    }
    
    try {
        stage('Run unit tests') {
            bat '"C:\\Program Files (x86)\\NUnit.org\\nunit-console\\nunit3-console.exe"  *** your test project***\\bin\\Debug\\AirTrafficMonitor.Tests.dll --result:TestResult.xml'
        }
    }
    finally {
        stage('Publish Test Results') {
            nunit testResultsPattern: 'TestResult.xml'
        }
    }
    
}
```
