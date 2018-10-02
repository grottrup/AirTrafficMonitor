# AirTrafficMonitor

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

5. Add a GitHub Web Hook in GitHub Settings with the following address: `http://ci3.ase.au.dk:8080/github-webhook/`

## How to add a Jenkins code coverage job

1. Add a dotCoverCoverageConfig.xml:

``` XML
<?xml version="1.0" encoding="utf-8"?>
<AnalyseParams>
  <TargetExecutable>C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe</TargetExecutable>
  <TargetArguments>bin\Debug\Calculator.Unit.Test.dll --result:TestResult.xml</TargetArguments>
  <TargetWorkingDir>Calculator.Unit.Test</TargetWorkingDir>
  <TempDir><!-- Directory for the auxiliary files. Set to system temp by default. --></TempDir>
  <Output>coverage_report.html</Output>
  <ReportType>HTML<!-- [HTML|JSON|XML|NDependXML]. A type of the report. XML by default. --></ReportType>
  <InheritConsole><!-- [True|False] Lets the application being analysed to inherit dotCover console. True by default. --> </InheritConsole>
  
  <!-- Coverage filters. It's possible to use asterisks as wildcard symbols.
  <Filters>
    <IncludeFilters>
      <FilterEntry>
        <ModuleMask> Module mask. </ModuleMask>
        <ClassMask> Class mask. </ClassMask>
        <FunctionMask> Function mask. </FunctionMask>
      </FilterEntry>
    </IncludeFilters>
    <ExcludeFilters>
      <FilterEntry>...</FilterEntry>
      <FilterEntry>...</FilterEntry>
      <FilterEntry>...</FilterEntry>
    </ExcludeFilters>
  </Filters>
  -->
  <!-- Attribute filters. It's possible to use asterisks as wildcard symbols.
  <AttributeFilters>
    <AttributeFilterEntry>...</AttributeFilterEntry>
    <AttributeFilterEntry>...</AttributeFilterEntry>
  </AttributeFilters>
  -->
</AnalyseParams>
```

2. Make a new job: http://ci3.ase.au.dk:8080/view/all/newJob
3. Give the job a name and choose a template. We used the TemplateBuildCoverage template given from the SWT course.
