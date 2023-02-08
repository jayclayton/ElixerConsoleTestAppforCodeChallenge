!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!                              !
!!!!!!!!!!!!!!     Written By Jay Clayton for the purposes of obtaining a positon of Application Architect             !!!!!!!!!!!!!!!!                              !
!!!!!!!!!!!!!!     this file contains instructions to install and run the Elixer code challenge test application       !!!!!!!!!!!!!!!!                              !
!!!!!!!!!!!!!!     please see below                                                                                    !!!!!!!!!!!!!!!!                              !
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!                              !




# ElixerConsoleTestAppforCodeChallenge
Coding Exercise – Security Questions
Using Visual Studio and c#, build a console app that stores answers to security question for a specified person.  It has the following flows :
•	Prompt for Name – Initial Flow: “Hi, what is your name?”
o	If the name has no stored questions, present the Store flow
o	Else, asks if the user wants to answer a security question : “Do you want to answer a security question?”
	If Yes, present the “Answer” flow
	Else re-do answers through the “Store” flow
•	Store : “Would you like to store answers to security questions?”
o	If yes, loop through provided questions and prompt them for answers, storing the answers
	Out of 10 total questions the user has to choose 3
o	Present the “Prompt for Name” when finished or user declined to store
•	Answer : present questions until either the user runs out of questions or answers one correctly
o	If the user answers correctly, congratulate the user
o	If the user runs out of questions, let them know
o	Go back to the Prompt for Name flow when finished

Any storage mechanism can be used as long as it is persistent so that after shutdown and restart a user that previously stored answers could answer a security question.
Use good coding practices.  Add a readme text file describe the design intent, design choices, and any other explanations.


Design Considerations:
  TTC (Time to completion)
  Iterative implementation
  Ease of deployment
  Expandability (Enhanceability)
  
  Basic Design is a series of nested loops
  please see .pdf for a diagram
  
  persistent storage is in the form of a json file with the username as the filename:
    decided on that because I did not want to muddy the waters by creating a relational database for essentially a static file storage
    plus, I needed   
  
  To install, you will need to download the folder ElixerCodeChallenge from this repo to your desktop.
  Then doubleclick on the powershell install script
    the script will:
      create a directory called: ?????? on the c: drive
      create permissions for that folder for everyone to use it
      copy the application folder an all of its contents to that folder
      create a desktop shortcut to the application
      
 To run  the application, doubleclick on the newly created desktop shortcut
