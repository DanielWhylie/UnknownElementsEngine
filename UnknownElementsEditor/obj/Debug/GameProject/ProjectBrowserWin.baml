   M S B A M L   `   `   `  ����P  LUnknownElementsEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:UnknownElementsEditor.GameProject!UnknownElementsEditor.GameProject  5   	   9    3UnknownElementsEditor.GameProject.ProjectBrowserWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:UnknownElementsEditor.GameProject     5   	     � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�60    � Title$ ProjectBrowserWin��5   	   $	��675��6#   $	��800��60   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��20q�6K   .+�5      d� -   5         d�Name$ openProjectButton��5   2   $��Open Project��6   $��48(�6i   d� 5      -   5        $ createProjectButton��5   4   $��Create Project��6   $��48(�6m   $��30,0,0,0q�6{   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��1��6K   $��20q�6X   .+�5      d� -   5        $ unknownNewsButton��5   ;   $��Unknown Elements News��6    d� 	IsChecked$
 TrueY�6r   $��32(�6�   $��0,0,0,0q�6�   5      �� 5   
   -   5         ��Name$ browserView��5   ;   $ 
Horizontal=�6   $��2��6.   .+�5      �� $	��800��6   
�������.+�5      �� $��24(�6   
�������Unknown Elements News:5      �� 5       $��16(�6   $	��800��6*   $	��415��66   
�������$��0,3,0,0q�6Z   *(News 1: Unknown Elements Project Starts.�� 5!   >   <:News 2: Added Basic Open Project and Create Project views.�� 5"   P   5#      5$      7   1UnknownElementsEditor.GameProject.OpenProjectView  5&      9   3UnknownElementsEditor.GameProject.CreateProjectView  5'      5)      5*      5,      