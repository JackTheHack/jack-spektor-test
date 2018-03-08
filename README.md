# Number Humanizer

*Running unit tests:*
Update ReSharper to latest version to run the NUnit tests.

*Running the project:*
Use CTRL+F5 to run the site.

## Technical details:

For number transformation Humanizer NuGet package was used. The disadvantage of that would be that the number would be limited to int.MaxValue.To support bigger numbers custom implementation with BigInt would be required.

Unit Tests were implemented using NUnit framework and covers both API and number transformation logic.

WebAPI framework was used for the web service implementation.

For UI implementation Bootstrap and HTML5 validation was used.
