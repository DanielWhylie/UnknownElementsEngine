   M S B A M L   `   `   `  ����P  LUnknownElementsEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:UnknownElementsEditor.GameProject!UnknownElementsEditor.GameProject  5      7    1UnknownElementsEditor.GameProject.OpenProjectView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:UnknownElementsEditor.GameProject     5      $	��450��5      $	��800��6,     � DataContext  5	      3  -UnknownElementsEditor.GameProject.OpenProject  5
   
   .��5      �� 
�������.+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ projectListBox��5   r    �� SelectedIndex$ 0��6   $	��200��6(   $	��200��64   $��20q�6A   ��6M   �� *ProjectInfos+��5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� $��Center=�6)   ��5   "   `� 5   &    �� StringFormat$ 	>{0}({1})��63   .1�5   *   ��  �� Path$ projectName�62   �� 5   *   $ projectPath�62   5   '   5      5      5      5      �� 5       $ Vertical=�6   $��Center=�60   $��150,100,0,0q�6M   .+�5!      �� $ 
Horizontal=�6   $��Center=�66   $��0,10,0,0q�6S   .+�5"      �� -   5         ��Name$ openProjectButton��5"   c   $
��Open��6   $	��100��6,    �� 	IsDefault . 6c   �� 5#      $
��Exit��6   $	��100��6,    �� IsCancel . $��10,0,0,0q�6H   5$      5%      5&      �� 5(   
   .+�5)      �� $	��600��6   $	��200��6!   $��0,0,0,0q�6.   ��5*      �� 5+      	 �� ImageSource	 6!   �� $ SelectedItem.screenshot�
 �� ElementName$
 projectListBox��5-      5.      5/      50      