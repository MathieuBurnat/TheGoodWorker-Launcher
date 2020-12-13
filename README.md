# TheGoodWorker-Launcher
## Description
I have to open a bunch of programs and urls **each morning** at my teleworking days.

So, i want a simple button that lunch my different things when i execute it.

## Goals
- [x] **The program is able to :**
    - [x] Executes wished application's list
    - [x] Browses wished url's list
- [x] **Into the configuration file**
    - [x] It's possible to manually add a new program
        - Example : - Discord : **C:/.../Discord.exe**
    - [x] It's possible to manually add a URL
        - Example : myurl : **wwww.myUrl.com**

## Get Started
- Download the last version of the program [here](https://github.com/MathieuBurnat/TheGoodWorker-Launcher/tree/dev/installer).
    - *Unzip the document whatever you want.*
- Open the file **TheGoodWorker-Launcher.dll.config**.
    - *Configure-it like the examples.*
    - *If you panic, keep calm and read comments or see examples below*
- Save and Enjoy  !
    - *oh. You just need to click on the .exe's file 0:).
### Configuration's examples

You need to go inside the configuration file *TheGoodWorker-Launcher.dll.config* to do that.

#### If you want to add an application :
Go inside the *application* section and add a line : 

```xml
    <applications>
      <add key="discord" value="C:\Users\MyUser\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\Discord.lnk" />
    </applications>
```
The **Key** value is the name of the application. It will be used when the interface shows graphical messages.

The **value** is the path of the application. You may have nocticed that the example links an *.Ink*, it's because the application supports .ink execution. 

It could be interesting to launch the .Ink of the application and not the .exe because the .Ink might launch the .exe with special parameters.
#### If you want to add a url :
Go inside the *urls* section and add a line : 

```xml
    <urls>
      <!-- Add your URLs to browse here ! -->
      <add key="KhanAcademia" value="https://fr.khanacademy.org/" />
    </urls>
```
The **Key** value is the name of the website. It will be used when the interface shows graphical messages.

The **value** is the url that you want to automatically launch.

## Versions 
All versions are available [here](https://github.com/MathieuBurnat/TheGoodWorker-Launcher/tree/dev/installer).

### Beta 1.0 (02.12.20)
- This is the first version of the application !
- It respects the goal's section.

*Actually in test, more informations will come later [...]*

## Author
Created by Mathieu Burnat ! :D