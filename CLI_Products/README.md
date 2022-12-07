## SaaS Products Import

We update our inventory of SaaS products from several sources.  Each source provides its content to us in a different format.  Write a command line tool in C# to import the products.

Input/output should be something like this:
 
````bash
$ import capterra feed-products/capterra.yaml

importing: Name: "GitHub";  Categories: Bugs & Issue Tracking, Development Tools; Twitter: @github
importing: Name: "Slack"; Categories: Instant Messaging & Chat, Web Collaboration, Productivity; Twitter: @slackhq
````

Considerations:

- It's not an iteractive application, use the command line arguments to pass the parameters to the application.
- Currently, we are importing products from 2 sites: capterra and softwareadvice.  They send us their weekly feed via email.  This weeks files are in /feed-products
- We plan to add a third provider soon who will make their feed available via csv output online via a url (you don't need to implement this, just keep it mind)
- Do not implement any data persistence code, just provide some dummy classes that echo what they are doing.  Keep in mind that the company is planning to switch from MySQL to MongoDB in 3 months.
- Please provide at least some unit tests (it is not required to write them for every class). Functional tests are also a plus.
- Please provide a short summary detailing anything you think is relevant, for example:

  - Installation steps
	->As a pre-requisite copy the folder "feed-products" from the solution along with its content files into C drive like "C:\feed-products". Assuming this is the source location for the products.

  - How to run your code / tests
	->This is a c# console application and code can be run either by installing nupkg file in system or from Visual studio(used VS2022 .net6.0). It needs 2 arguments, one for source name and second for path name like "capterra feed-products\capterra.yaml" or "softwareadvice feed-products\softwareadvice.json".
  - Where to find your code
  - Was it your first time writing a unit test, using a particular framework, etc?
  	->I am already using xUnit for test cases. Here I have used nUnit.
  - What would you have done differently if you had had more time.Etc.
  	->I could have added provision for logs by adding a separate log file. Also I could have done the full implementation using database like MySql or Sql server.
* * * 

## Code Submission

As a result of this assignment we expect to recieve a link to your shared git repository (i.e. Bitbucket or Gitlab offer free private repos).
Having full commit history is optional but would be considered as a plus.
