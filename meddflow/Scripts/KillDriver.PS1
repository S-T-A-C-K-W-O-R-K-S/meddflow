$drivers = "chromedriver", "firefoxdriver", "msedgedriver"

ForEach ($driver in $drivers)
{
    Try {Stop-Process -Name $driver -ErrorAction Stop}
    Catch [System.Management.Automation.RuntimeException] {"No Instances Found: " + $driver}
    Finally {$Error.Clear()}
}
