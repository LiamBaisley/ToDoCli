# ToDoCli
A simple CLI tool to manage your todo list in a console environment.

# Installation
## Prerequisits:
  * The dotnet runtime must be installed on the users PC
## How to install?
  * Clone the repo
  * Navigate to the project root
  * Run the following dotnet command: dotnet pack
  * Run the following dotnet command: dotnet tool install --global --add-source ./nupkg ToDoCLI
  
## How to uninstall?
  * Run: dotnet tool uninstall --global ToDoCLI

## Other options
   * The tool can also be run by navigating to ./ToDoCLI/ToDoCLI and running: dotnet run &lt arguments &gt

# Available commands:
* Add -T "<Title of todo>"
   * Adds a todo to list
* Complete
   * Lists todos in a navigational menu, use enter to complete a todo and ctrl+x to exit the menu.
