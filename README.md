# ToDoCli

A simple CLI tool to manage your todo list in a console environment. Now including support for project specific todos!

# Installation

## Prerequisites:

- The dotnet runtime must be installed on the users PC

## How to install?

- Clone the repo
- Navigate to the project root
- Run the following dotnet command: dotnet pack
- Run the following dotnet command: dotnet tool install --global --add-source ./nupkg todo
  - This makes the tool available in any directory on the PC
  - The tool is now available using the command "todo" with relevant arguments.

## How to uninstall?

- Run: dotnet tool uninstall --global todo

## Other options

- The tool can also be run by navigating to ./ToDoCLI/ToDoCLI and running: dotnet run \<arguments\>

# Available commands:

- list
  - Lists the currently active todos. Defaults to current project, if no todo's are found it lists all Todo's.
  - ** Available Arguments **
    - -e Lists all todos, bypasses default of listing only the todo's of your current project.
- add
  - Adds a todo to list
  - **Available arguments**
    - -t \<Todo title text here\>
    - -l Specifies that this todo is for a local project, and prompts you to select a project folder within your current directory.
- complete
  - Lists todos in a navigational menu, use enter to complete a todo and ctrl+x to exit the menu. Defaults to your local project and reverts to global todos if no local todos are found.
  - **Available arguments**
    - -i \<Todo index as seen in list command\>
    - -e Overrides defaulting to local and uses all todos instead.
