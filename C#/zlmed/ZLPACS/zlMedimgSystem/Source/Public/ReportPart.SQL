--删除脚本(为了可以重复执行必须)
delete from partlist where ID = '648D1891-82E0-4D2D-A57E-D2C04E6EBD95';

insert into partlist
  (ID, ---ID
   TITLE, ---SP名称  
   OBJNAME, ---SP设计信息所在类   
   FILENAME, ---SP设计信息所在文件名
   ICON, ---图标 
   REMARK, ---注释
   EDITION, ---版本
   KIND, ---类型(1.普通部件,2.数据部件)
   SEQNUM, ---排列顺序号
   ISOUTER, ---是否由第三方开发(默认为0)  
   AUTHOR, ---开发者     
   ISSUER, ---发行者 
   ISSUEDATE, ---发行日期     
   ISGRANTED) ---是否授权,此处需要指定为1
values
  ('648D1891-82E0-4D2D-A57E-D2C04E6EBD95',
   '报告部件',
   'ZLSoft.BusinessHome.Application.SmartForms.SmartParts.ReportPartDesignInfo',
   'ZLSoft.BusinessHome.SmartForm.ReportPartDesignerInfo.dll',
   '',
   '',
   '1.0.0.0',
   1,
   19,
   0,
   'hjh',
   'ZLSOFT',
   to_date('2019-04-30', 'yyyy-mm-dd'),
   1);
