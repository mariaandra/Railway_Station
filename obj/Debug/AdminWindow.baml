   M S B A M L   `   `   `  ????I  ERailway System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Railway_SystemRailway_System  5   	        Railway_System.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Railway_System     5   	   $	??600??5   	   $	??395??6   $	??800??5	   	   $	??500??6   ???#29324a  ? Icon$  images/icon.ico??5   	    ? 
ResizeMode$ 	CanResize=?5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 0q?6      CornerRadius$ 0??5         CaptionHeight$ 0Q?5         UseAeroCaptionButtons .    ResizeBorderThickness$ 7q?5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??95??6   ?? 5      $??7* ?6   $	??230??5      ?? 5      $??0* ?6   	 ? RowDefinitions	 5    
   ?? 5!      $??25 ?6   ?? 5"      .+?5%   
   ?? $??1??6   $??0??5&      ???#adaddf$??
10 10 0 10q?5(      ._?5*      ? .+?5+      ?? ???#18223c$??2q?5,      .+?5.      ?? $??Center=?6    $??0 5 0 0q?5/      $??35(?50      
 ?? TextAlignment$
 Center=?51      ?? 52      -   5         ?? TextDecorations$
 None{?54      .?63   ??55      ?? 56   "    ?? 
TargetType" ??6(   .?57   &   ??  ?? Property ? ?? ?? Value ?#ffffff6C    ?? Triggers 58   &   P? 59   "    P? Property ?@??IsMouseOver P? Value . . ?5:   &   ??  ? ?? ?#ffcd4f6C   5;   #   5=      .?5>   +   .?5@      👤?? ?? 5A      $??
Contul Meu??6(   $??14(?5B       $??0 0 0 0q?5C       $??Center=?5D       $
 Center=?5E       5F      5G      ?? 5I      -   5         ??Name$
 rute??5I       $??Center=?6.   $??0 5 0 0q?5J      $??35(?5K      $
 Center=?5L      ?? 5M      -   5        $
 None{?5O      .?63   ??5P      ?? 5Q   "   " ??6(   .?5R   &   ??  ? ?? ?#ffffff6C    5S   &   P? 5T   "    ?@??IsMouseOver . . ?5U   &   ??  ? ?? ?#ffcd4f6C   5V   #   5X      .?5Y   +   .?5[      🚆?? ?? 5\      $??Administrare??6(   $??11(?5]       $??0 2 0 0q?5^       $??Center=?5_       $
 Center=?5`       5a      5b      5c      ?? 5e      $??Bottom=?6   .+?5g      ?? $??Center=?6    $??35(?5i      $
 Center=?5j      ?? 5k      -   5        $
 None{?5m   !   .?68   ??5n   "   ?? 5o   &   " ??6,   .?5p   *   ??  ? ?? ?#ffffff6G    5q   .   P? 5r   2    ?@??IsMouseOver . . ?5s   6   ??  ? ?? ?#ffcd4f6S   5t   3   5v   '   .?5w   3   .?5y   "   🚪?? ?? 5z   "   $??Deconectare??6,   $??14(?5{   ,   $??0 0 0 10q?5|   ,   $??Center=?5}   ,   $
 Center=?5~   ,   5   #   5?      5?      5?      5?      ?? 5?   
   -   5        $??top_bar??5?      $??2??5?      ???#1f273b._?5?      ? $??Stretch=?6   .+?5?      ?? $??Railways??6   ???#f2f2ff$??2 0 0 0q?5?      $1??+/Railway System;component/fonts/#Top Modern)?6)   $??16(?5?      ?? 5?      $??Right=?6    ?? Orientation$ 
Horizontal=?5?      .+?5?      ?? -   5        $??minimize_button??5?      $??25??5?      $??20??5?      $??_??5?      $??0q?5?      ???#bbccf2$
??Bold"?5?      $??23(?5?      $	??-12q?5?      $	??Top=?5?      
?????? 5?      ?? 5?      -   5        $??maximize_button??5?      $??25??5?      $??20??5?      $	??□??5?      $??-8q?5?      $	??Top=?5?      $??0q?5?      ???#ccccf2$
??Bold"?5?      $??23(?5?      
?????? 5?      ?? 5?      -   5        $??exit_button??5?      $??25??5?      $??20??5?      $	??╳??5?      $??0q?5?      ???#ccccf2$
??Bold"?5?      $??	0 0 2.5 0q?5?      
?????? 5?      5?      5?      5?      &   System.Windows.Controls.DataGrid  5?   
   -	   5          Name$ trains??5?      $??1??6#   $??1??63   $??28,28,25,29q?6@   5?      5?      