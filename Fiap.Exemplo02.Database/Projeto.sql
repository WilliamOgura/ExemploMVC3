CREATE TABLE [dbo].[Projeto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(150) NOT NULL, 
    [Descricao] VARCHAR(255) NOT NULL, 
    [DataInicio] DATETIME NULL, 
    [dataTermino] DATETIME NULL, 
    [Entregue] BIT NOT NULL, 
    CONSTRAINT [FK_Projeto_Grupo] FOREIGN KEY ([Id]) REFERENCES [Grupo]([Id]) 
)
