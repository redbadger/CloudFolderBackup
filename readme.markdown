Cloud Folder Backup
===================

Cloud Folder Backup (CFB) is an uber simple app that takes a folder, zips it and uploads it to Rackspace Cloud Files.

It was written to solve a very simple problem and to try out the Rackspace Cloud Files API.  
You can read more about it here: <http://red-badger.com/Blog/post/Cloud-Folder-Backup-A-Rackspace-Cloud-Files-Experiment.aspx>

Configuration
-------------
CFB is configured entirely via the app.config and requires 4 values:

* Username - your Rackspace Cloud Files username
* API Key - your Rackspace Cloud Files API key
* Source Folder Path - which folder on the host machine you want to be backed up
* Destination Container - which container in your Rackspace Cloud Files account you want to the zip to be placed.  
  This container must already exist.

These are configured in app.config of your app:

	<cloudFolderBackupGroup>
		<cloudFolderBackup>
			<credentials username="" apiKey="" />
			<operation sourceFolderPath="" destinationContainer="" />
		</cloudFolderBackup>
	</cloudFolderBackupGroup>

This .zip file created will be named after the source folder.  So if your source folder path is c:\MyFolder\MyFiles - the zip that gets uploaded to your container will be MyFiles.zip.

Running
-------
Ultimately running CFB is a single method call, as all the configuration is dealt with in the app.config:

	Agent.Run();

The source-code comes with a simple console app that wraps a little logic around this call.  
By default it provides a little feedback, displays any exceptions that may have been thrown and awaits a key-press to close the application:

	Success!
	
	Finished: 06/06/2010 15:09:22
	Press any key to exit.

**Silent Mode**  
Silent Mode is handy should you wish to use CFB with Windows Task Scheduler or similar.

You can run the console app in silent mode by passing the *-s* switch.  
This writes nothing to the console and exits immediately after the operation is complete, regardless of whether it succeeded or failed.  

Whether you run the console app in silent mode or not, the same information is written to the log, so you won't lose any exceptions.

Logging
-------
CFB uses a very basic log4net configuration to log to a text file.

By default it will log to *InstallPath*\logs\CloudFolderBackup.log.  This can be changed via the log4net configuration in the app.config should you wish.  
The Rackspace C# .Net binding also uses log4net, so you'll see output in the log file from that assembly too.

Referenced Assemblies
---------------------
CFB doesn't really do anything complicated, that's dealt with by the hard work of others!

* Rackspace Cloud Files C#.Net API Binding  
  <http://github.com/rackspace/csharp-cloudfiles>
* DotNetZip Library  
  <http://dotnetzip.codeplex.com/>
* log4net  
  <http://logging.apache.org/log4net/index.html>
* MSpec  
  <http://github.com/machine/machine.specifications>
* Rhino.Mocks  
  <http://www.ayende.com/projects/rhino-mocks.aspx>

Caveats
-------
I only ever intended on using this with quite small files - it uses an memory stream internally to create the zip, so if you point this at a huge folder you might cause yourself some problems.  
The code is presented as-is with no guarantees etc.