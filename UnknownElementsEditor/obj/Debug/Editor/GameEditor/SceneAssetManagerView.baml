   M S B A M L   `   `   `  ����P  LUnknownElementsEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:UnknownElementsEditor.Editor.GameEditor'UnknownElementsEditor.Editor.GameEditor  5      U/clr-namespace:UnknownElementsEditor.GameProject!UnknownElementsEditor.GameProject  5      C    =UnknownElementsEditor.Editor.GameEditor.SceneAssetManagerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:UnknownElementsEditor.Editor.GameEditor     5      Cproject/clr-namespace:UnknownElementsEditor.GameProject     5      .��5      �� .+�5   
   �� .+�5      �� $��0��6   $��14(�6%   $��SemiBold"�63     �� Padding$  5,0,0,3q�6I   ��5      �� 5       �� Path$ projectName�6    �� StringFormat$
 >{0}��61   5      �� 5      -   5         ��Name$ activateSceneComboBox��5   �    �� SelectedIndex$ 0��6   $��	50,0,50,0q�6t   ��6)   �� *projectScenes+��5      �� 5      .R�5      ��  �� TextAlignment$ Center=�6_   ��6$   �� *	SceneName+$ Active Scene: {0}��6_   5      5      �� 5      -   5         ��Name$ addSceneButton��5   �   $��0��6   $	��100��6"   $��25��6.   $��	Add Scene��6:   
�������$��0,5,0,0q�6   6�   5      �� 5   
   $��1��6   $	��675��6$   $
��Auto=�61   $
��Auto=�6V   .��5       �� -   5         ��Name$ sceneItemControl��5    A   ��6   �� *projectScenes+��5!      �� 5"      .R�5#      �� 5$      ��5&      �� 5'      .R�5(      9�  9�Name$ sceneExpander��6H   	 9� 
IsExpanded	 . 
���������5)      �� 5*   "   
 �� Orientation$
 
Horizontal=�6-   .+�5+   &   �� ��60   �� *	SceneName+�� 5,   &   $ removeSceneButton��6�   -   5        $��Remove Scene��5,   -   
�������$��10,0,0,0q�6�   
 � Tag 6x   �� 6�   5-   #   .��5/      �� .+�50   "   �� $��Center=�6-   $��0,5,0,0q�6J   .+�51   &   o� $��20��6+   $	��Top=�67   .@�52   *   m� $��	Add Asset��63   
�������.@�53   .   m�  m�Name$ squareMenuItem��6j   -   5        $��Square��53   7    6Z   �� 6j   m� 54   .   $ circleMenuItem��6j   -   5        $��Circle��54   7    6Z   �� 6j   55   +   56   '   57   #   �� 59   "    ��Name$ assetListBox��6�   -   5        $ 0��59   *   ��6<   �� *SceneAssets+��5:   &   �� 5;   *   .R�5<   .   �� $
 
Horizontal=�69   .+�5=   2   �� $��Center=�6X   ��6<   �� *
EntityName+6X   �� 5>   2   $ removeAssetButton��6�   -   5        $��Remove��5>   9   
�������$��10,0,0,0q�6�    6~   �� 6�   5?   /   5@   +   5B   #   5C      5D      5E      5G      5H      5I      5J      