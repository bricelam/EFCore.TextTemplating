CREATE TABLE [dbo].[Enum]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL, 
    [Attribute] NVARCHAR(10) NULL, 
    [Type] INT NULL, 
    [Type2] INT NULL, 
    [Type3] INT NULL, 
    [Introduce] NTEXT NULL,
)

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the data table "Enum" comment |*| EntityClassInfo: {"Name":"TestEnum","UsingNamespaces":"System.Linq"}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Id" comment |*| EntityPropertyInfo:{"Attributes":[{"Code":"DatabaseGenerated(DatabaseGeneratedOption.None)"}]}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Id'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Attribute" comment |*| EntityPropertyInfo:{"Attributes":[{"Code":"Obsolete(\"Test Attribute\")"}]}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Attribute'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Type" comment |*| EntityPropertyInfo:{"Enum":{"Name":"EnumType","Comment":"This is "EnumType" comment","Values":[{"Name":"Type1","Value":1,"Comment":"This is "Type1" comment"},{"Name":"Type2","Value":2,"Comment":"This is "Type2" comment"},{"Name":"Type3","Comment":"This is "Type3" comment"}]}}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Type'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Type2" comment |*| EntityPropertyInfo:{"Enum":{"Name":"EnumType","Comment":"This is "EnumType" comment"}}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Type2'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Type3" comment |*| EntityPropertyInfo:{"Enum":{"Name":"EnumType","Comment":"This is "EnumType" comment","Values":[{"Name":"Type1","Value":1,"Comment":"This is "Type1" comment"},{"Name":"Type2","Value":2,"Comment":"This is "Type2" comment"},{"Name":"Type3","Comment":"This is "Type3" comment"}]}}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Type3'

GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'This is the table field "Introduce"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Enum', @level2type = N'COLUMN', @level2name = N'Introduce'
