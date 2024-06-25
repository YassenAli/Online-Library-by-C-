/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     5/12/2024 6:37:48 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_INHERITAN_UserDetails')
alter table ADMIN
   drop constraint FK_ADMIN_INHERITAN_UserDetails
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOOK') and o.name = 'FK_BOOK_CONTAIN_WISHLIST')
alter table BOOK
   drop constraint FK_BOOK_CONTAIN_WISHLIST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BORROWED') and o.name = 'FK_BORROWED_BORROWS_STUDENT')
alter table BORROWED
   drop constraint FK_BORROWED_BORROWS_STUDENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BORROWED') and o.name = 'FK_BORROWED_HAS_BOOK')
alter table BORROWED
   drop constraint FK_BORROWED_HAS_BOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STUDENT') and o.name = 'FK_STUDENT_INHERITAN_UserDetails')
alter table STUDENT
   drop constraint FK_STUDENT_INHERITAN_UserDetails
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STUDENT') and o.name = 'FK_STUDENT_PUT_BOOK_WISHLIST')
alter table STUDENT
   drop constraint FK_STUDENT_PUT_BOOK_WISHLIST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WISHLIST') and o.name = 'FK_WISHLIST_PUT_BOOK2_STUDENT')
alter table WISHLIST
   drop constraint FK_WISHLIST_PUT_BOOK2_STUDENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WRITE_BY') and o.name = 'FK_WRITE_BY_WRITE_BY_BOOK')
alter table WRITE_BY
   drop constraint FK_WRITE_BY_WRITE_BY_BOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WRITE_BY') and o.name = 'FK_WRITE_BY_WRITE_BY2_AUTHOR')
alter table WRITE_BY
   drop constraint FK_WRITE_BY_WRITE_BY2_AUTHOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMIN')
            and   type = 'U')
   drop table ADMIN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AUTHOR')
            and   type = 'U')
   drop table AUTHOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOOK')
            and   name  = 'CONTAIN_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOOK.CONTAIN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BOOK')
            and   type = 'U')
   drop table BOOK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BORROWED')
            and   name  = 'BORROWS_FK'
            and   indid > 0
            and   indid < 255)
   drop index BORROWED.BORROWS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BORROWED')
            and   type = 'U')
   drop table BORROWED
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STUDENT')
            and   name  = 'PUT_BOOK_FK'
            and   indid > 0
            and   indid < 255)
   drop index STUDENT.PUT_BOOK_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('STUDENT')
            and   type = 'U')
   drop table STUDENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserDetails')
            and   type = 'U')
   drop table UserDetails
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WISHLIST')
            and   type = 'U')
   drop table WISHLIST
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('WRITE_BY')
            and   name  = 'WRITE_BY2_FK'
            and   indid > 0
            and   indid < 255)
   drop index WRITE_BY.WRITE_BY2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('WRITE_BY')
            and   name  = 'WRITE_BY_FK'
            and   indid > 0
            and   indid < 255)
   drop index WRITE_BY.WRITE_BY_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WRITE_BY')
            and   type = 'U')
   drop table WRITE_BY
go

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table ADMIN (
   USERID               int                  not null,
   FNAME                varchar(50)          not null,
   LNAME                varchar(50)          not null,
   EMAIL                varchar(150)           null,
   PASSWORD             varchar(150)           null,
   constraint PK_ADMIN primary key (USERID)
)
go

/*==============================================================*/
/* Table: AUTHOR                                                */
/*==============================================================*/
create table AUTHOR (
   AUTHORID             int                  not null,
   NAME                 varchar(150)          not null,
   constraint PK_AUTHOR primary key (AUTHORID)
)
go

/*==============================================================*/
/* Table: BOOK                                                  */
/*==============================================================*/
create table BOOK (
   ISBN                 int                  not null,
   TITLE                varchar(150)          not null,
   PUBLICATIONYEAR      datetime             not null,
   CATEGORY             varchar(150)          not null,
   constraint PK_BOOK primary key (ISBN)
)
go

/*==============================================================*/
/* Index: CONTAIN_FK                                            */
/*==============================================================*/


go

/*==============================================================*/
/* Table: BORROWED                                              */
/*==============================================================*/
create table BORROWED (
   ISBN                 int                  not null,
   USERID               int                  not null,
   BORROWDATE           datetime             not null,
   RETURNDATE           datetime             not null,
   constraint PK_BORROWED primary key (ISBN, USERID)
)
go

/*==============================================================*/
/* Index: BORROWS_FK                                            */
/*==============================================================*/




create nonclustered index BORROWS_FK on BORROWED (USERID ASC)
go

/*==============================================================*/
/* Table: STUDENT                                               */
/*==============================================================*/
create table STUDENT (
   USERID               int                  not null,
   WIS_USERID           int                  null,
   FNAME                varchar(50)          not null,
   LNAME                varchar(50)          not null,
   EMAIL                varchar(150)           null,
   PASSWORD             varchar(150)           null,
   constraint PK_STUDENT primary key (USERID)
)
go

/*==============================================================*/
/* Index: PUT_BOOK_FK                                           */
/*==============================================================*/




go

/*==============================================================*/
/* Table: UserDetails                                                */
/*==============================================================*/
create table UserDetails (
   FNAME                varchar(50)          not null,
   LNAME                varchar(50)          not null,
   USERID               int                  not null,
   USERTYPE             varchar(50)          not null,
   EMAIL                varchar(150)           null,
   PASSWORD             varchar(150)           null,
   constraint PK_UserDetails primary key (USERID)
)
go

/*==============================================================*/
/* Table: WISHLIST                                              */
/*==============================================================*/
create table WISHLIST (
   USERID               int                  not null,
   ISBN                 int                  not null,
   constraint PK_WISHLIST primary key (USERID, ISBN)
)
go

/*==============================================================*/
/* Table: WRITE_BY                                              */
/*==============================================================*/
create table WRITE_BY (
   ISBN                 int                  not null,
   AUTHORID             int                  not null,
   constraint PK_WRITE_BY primary key (ISBN, AUTHORID)
)
go

/*==============================================================*/
/* Index: WRITE_BY_FK                                           */
/*==============================================================*/




create nonclustered index WRITE_BY_FK on WRITE_BY (ISBN ASC)
go

/*==============================================================*/
/* Index: WRITE_BY2_FK                                          */
/*==============================================================*/




create nonclustered index WRITE_BY2_FK on WRITE_BY (AUTHORID ASC)
go

alter table ADMIN
   add constraint FK_ADMIN_INHERITAN_UserDetails foreign key (USERID)
      references UserDetails (USERID)
go

alter table BOOK
   add constraint FK_BOOK_CONTAIN_WISHLIST foreign key (USERID, ISBN)
      references WISHLIST (USERID, ISBN)
go

alter table BORROWED
   add constraint FK_BORROWED_BORROWS_STUDENT foreign key (USERID)
      references STUDENT (USERID)
go

alter table BORROWED
   add constraint FK_BORROWED_HAS_BOOK foreign key (ISBN)
      references BOOK (ISBN)
go

alter table STUDENT
   add constraint FK_STUDENT_INHERITAN_UserDetails foreign key (USERID)
      references UserDetails (USERID)
go

alter table STUDENT
   add constraint FK_STUDENT_PUT_BOOK_WISHLIST foreign key (WIS_USERID, ISBN)
      references WISHLIST (USERID, ISBN)
go

alter table WISHLIST
   add constraint FK_WISHLIST_PUT_BOOK2_STUDENT foreign key (USERID)
      references STUDENT (USERID)
go

alter table WRITE_BY
   add constraint FK_WRITE_BY_WRITE_BY_BOOK foreign key (ISBN)
      references BOOK (ISBN)
go

alter table WRITE_BY
   add constraint FK_WRITE_BY_WRITE_BY2_AUTHOR foreign key (AUTHORID)
      references AUTHOR (AUTHORID)
go
