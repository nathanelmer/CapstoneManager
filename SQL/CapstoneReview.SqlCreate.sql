USE [master]

IF db_id('CapstoneManager') IS NULl
  CREATE DATABASE [CapstoneManager]
GO

USE [CapstoneManager]
GO


DROP TABLE IF EXISTS [Teacher];
DROP TABLE IF EXISTS [Student];
DROP TABLE IF EXISTS [Progress];
DROP TABLE IF EXISTS [Class];
DROP TABLE IF EXISTS [TeacherClass];
GO

CREATE TABLE [Teacher] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(255) NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Student] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ClassId] int NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [ProposalTitle] nvarchar(255) NOT NULL,
  [ProgressId] int NOT NULL,
  [Note] nvarchar(255)
)
GO

CREATE TABLE [Progress] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [ImageUrl] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Class] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [TeacherClass] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ClassId] int NOT NULL,
  [TeacherId] int NOT NULL
)
GO

ALTER TABLE [Student] ADD FOREIGN KEY ([ProgressId]) REFERENCES [Progress] ([Id])
GO

ALTER TABLE [Student] ADD FOREIGN KEY ([ClassId]) REFERENCES [Class] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [TeacherClass] ADD FOREIGN KEY ([TeacherId]) REFERENCES [Teacher] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [TeacherClass] ADD FOREIGN KEY ([ClassId]) REFERENCES [Class] ([Id]) ON DELETE CASCADE
GO
