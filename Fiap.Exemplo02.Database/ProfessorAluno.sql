CREATE TABLE [dbo].[ProfessorAluno]
(
	[ProfessorId] INT NOT NULL , 
    [AlunoId] INT NOT NULL, 
    PRIMARY KEY ([AlunoId], [ProfessorId]), 
    CONSTRAINT [FK_ProfessorAluno_Professor] FOREIGN KEY ([ProfessorID]) REFERENCES [Professor]([Id]), 
    CONSTRAINT [FK_ProfessorAluno_Aluno] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno]([Id])
)
