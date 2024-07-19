
# Deployment instructions
This document is a step-by-step guide to building and start application using docker container. The `docker-compose.yml` file has been prepared and is included in the source code


## Start the container
+ Download and extract source 
+ Go to PTFintect folder
+ Run command ``` docker-compose up -d ``` to build container. 
+ There will be 3 images created including:
```
+ The image for the server side would be: ptfintech-appserver
+ The image for the client side would be: ptfintech-appclient
+ Database server: postgres

```
![doimg](/images/dockerimage.png "doimg")

+ After a successful build, these containers will be started. To check app running running status you can use the command `docker-compose ps` 
+ A set of user accounts and demo data have also been created for your ease of use

## Test the Web API
+ The RESTful API part will run on port 8080, visit link: http://localhost:8080
+ You can view the API technical documentation, as well as test the results of each endpoint from the server side. access link http://localhost:8080/swagger/index.html

![apidoc](/images/apidoc.png "apidoc")

## Test the end user interface
+ You access the link http://localhost:8000/ to open the user interface. 
+ You can register yourself for a new account by clicking the register button `register now` an account registration interface will open according to the link http://localhost:8000/register 
![register](/images/reg.png "register new account")
+ Or log in to the system at the link http://localhost:8000/login with the list of pre-created accounts as follows: 
![login](/images/login.png "user login")


    | Account | Password  |
    |--------|------------|
    | admin | abc@123 |
    | john | abc@123 |
    | anan | abc@123 |
    | laura | abc@123 |

+ The Home page will display a list of your tasks.

    1. You can add new tasks
    2. or, delete an existing task

![task](/images/tasks.png "task")
