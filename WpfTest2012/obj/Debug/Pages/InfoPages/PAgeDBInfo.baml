   M S B A M L   `   `   `  ????F  BWpfTest2012, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfTest2012.PagesWpfTest2012.Pages  5      "    WpfTest2012.Pages.PAgeDBInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WpfTest2012.Pages     5        N? Title$  
PAgeDBInfo??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??7* ?6   ?? 5      $	??83* ?6   .+?5   
   ?? 
???  ??6   ?? 5   
   -   5        $??Right=?5      $	??100??5      $??Print??5      ?? 5   
   -   5        $
??Left=?5      $	??100??5      $??To Excel??5      &   System.Windows.Controls.DataGrid  5   
   -   5        $??GridUserList??5         
IsReadOnly .    AutoGenerateColumns .  $??1??5    )   $??1??6:      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ ID??5#         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5$      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%      ?? *Id+  5'      $% ФИО пользователя??5(      $ 5* 5)         
FontFamily$ Segoe UI Semibold)?5+       5*      ?? *
FullName+5+        5.      $ Роль??5/      $ 3* 50       51      ?? *	Role.Name+  54      $ 
Логин??55      $ 2* 56       57      ?? *Login+  59      $ Пароль??5:      $ 2* 5;       5<      ?? *
Password+  5?      $+ %Последнее изменение??5@      $ 3* 5A       5B      ?? *LastUpdateInfoTime+5E      5F      5G      