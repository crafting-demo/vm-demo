# Development with a Windows VM

This demo shows how to develop using a Windows VM together
with a Crafting sandbox leveraging the sandbox lifecycle
to dynamically manage the lifecycle of the Windows VM.

This demo contains:

- Dotnet based eShopOnWeb (forked from this [Example](https://github.com/dotnet-architecture/eShopOnWeb))
  built and running in an EC2 Windows VM;
- Java based logging service built and running in a sandbox workspace;
- Redis running in a sandbox serving as an in-memory cache for eShopOnWeb.

The sandbox automatically manages the EC2 Windows VM based on the lifecycle
and establishes the communication between eShopOnWeb, logging service and Redis.

During startup, the `dev` workspace will sync source code to the Windows VM,
builds and launches remotely, controlled by a daemon in the workspace.
The eShopOnWeb will communicate with the logging service and Redis in the sandbox.

For convinience, Web RDP ([guacamole](https://guacamole.apache.org)) is integrated to 
access the Windows on the web.
Click the endpoint `windows` to access the Windows desktop
or click the resource `windows` to see the detailed instructions.
