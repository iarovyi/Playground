$hostPath = ".\bin\Debug\OrleansHost.exe"
$pathToConfig = ($hostPath + ".config");

$content = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.diagnostics>
    <trace autoflush="true" indentsize="0">
      <listeners>
        <remove name="*" />
      </listeners>
    </trace>
    <switches>
      <add name="traceLevel" value="2" />
    </switches>
  </system.diagnostics>
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <runtime>
    <gcServer enabled="true" />
    <gcConcurrent enabled="false" />
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.IO.Compression" publicKeyToken="b77a5c561934e089" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-4.1.2.0" newVersion="4.1.2.0" />
      </dependentAssembly>
	  <dependentAssembly>
        <assemblyIdentity name="Microsoft.Extensions.DependencyInjection.Abstractions" publicKeyToken="adb9793829ddae60" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-1.1.1.0" newVersion="1.1.1.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Extensions.DependencyInjection" publicKeyToken="adb9793829ddae60" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-1.1.1.0" newVersion="1.1.1.0" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Security.Cryptography.X509Certificates" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-4.1.1.0" newVersion="4.1.1.0" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Collections.Immutable" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-1.2.1.0" newVersion="1.2.1.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>
"@

Set-Content -Path $pathToConfig -Value $content
& $hostPath;

