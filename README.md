# rcon-command-line
Simple command line program for sending rcon commands to source servers. This is handy if you need to run a command on a local or remote server immediately after building and copying a plugin for instance.

## Installation

Download the release and extract to the folder of your choice.

If you want to build the binaries yourself, you will have to add the dependencies first.

## Dependencies

[QueryMaster](https://querymaster.codeplex.com/) - This is used to send the RCON commands to the server.

## Usage

Run the executable with command line arguments for the ip, port, password and the command the server should run.

#### Example

```
rcon.exe -ip localhost -port 27015 -password "abc123" -cmd "sm plugins reload my_plugin"
```
