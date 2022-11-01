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
   * The tool can also be run by navigating to ./ToDoCLI/ToDoCLI and running: dotnet run \<arguments\>

# Available commands:
* list
   * Lists the currently active todos
* add
   * Adds a todo to list
   * **Available arguments**
     + -t \<Todo title text here\>
* complete
   * Lists todos in a navigational menu, use enter to complete a todo and ctrl+x to exit the menu.
   * **Available arguments**
     + -i \<Todo index as seen in list command\>
