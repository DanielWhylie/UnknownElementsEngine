# UnknownElementsEngine
This is a Final Year Project created by Daniel Whylie.  
The project features a rudimentary prototype of a 2D game engine made in C# using WPF(main graphical interface), WritableBitmapEx(Graphics for editor/runtime view), DataContracts(XML Serialisation).  

## Features:
- Allows user to create a project in the file location of their choosing.  
- Allows to select from different templates.
- Allows user to open existing projects.
- Serialisation using XML DataContracts.
- Allows for Saving, Exiting, Screen view change.
- Enables user to create new scenes, and swap views between them.
- Enables user to add a removable square entity and/or circle entity.
- Enables user to add removable components to each entity(Transform, Gravity, BoxCollider2D(Not a fully implemented class), Script(Reads from text file))
- Allows user to see properties of entities e.g. components they contain.
- Opens new window to view runttime of project(currently bugged, editor view also acts)
