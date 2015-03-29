# rcon-command-line
Simple command line program for sending rcon commands to source servers. This is handy if you need to run a command on a local or remote server immediately after building and copying a plugin for instance.

## Installation

Download the source code, add the dependencies, and then build the binaries yourself.

## Dependencies

[QueryMaster](https://querymaster.codeplex.com/) - This is used to send the RCON commands to the server. Copy and rename the executable if you want.

## Usage

Run the executable with command line arguments for the ip, port, password and the command the server should run.

#### Example

```
RCONUtility.exe -ip localhost -port 27015 -password "abc123" -cmd "sm plugins reload my_plugin"
```
