   M S B A M L   `   `   `  ????  Fractal    Fractal.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  
MainWindow??5   	   $	??800??6   $	??800??6)   .??5      ? .+?5	   
   ?? $??42(?6   .??6    Sierpinski Triangle65   ?? 5
   
   $??16(?6   $??10,70,10,599q?6    $????To begin, three points are drawn - each representing a corner of a triangle. Two of these points are randomly 
selected, a new point is then  drawn between these two. After this, a new point of the original three is 
 randomly selected - a new point is then drawn between the new point that was drawn in the previous step 
 and the randomly selected one. This process is then repeated over and over. 
 You will notice a pattern emerges. This happens every time, but it has never been mathematically proven...??5      .??6*  5      ?? 5   
   -   5        $??StartButton??5      $	??100??5      $??50??5      $??20(?5      $	??top=?5      $
??Left=?5      $??10, 190, 10, 10q?5      .??5      Start5      ?? 5   
   -   5        $??
stopButton??5      $	??100??5      $??50??5      $??20(?5      $	??top=?5      $
??Left=?5      $??10, 260, 10, 10q?5      .??5!   
   Stop5"      ?? 5#   
   $??2q?5$      
???   ?$??Center=?5&      $??Center=?5'      $	??399??5(      $	??399??5)      $??10, 10, 10, 10q?5*      ._?5+      ?? -   5        $??
MainCanvas??5+      $	??370??5,      $	??370??5-      $??Center=?5.      $??Center=?5/      50      ?? 51   
   $??355,600,355,165q?6    ?? TextAlignment$ Center=?6-   Amount of dots:6U   ?? 52   
   -   5        $??Counter??52      $??355,620,355,125q?6#   $ Center=?6<   $??24(?6S   6c   53      54      