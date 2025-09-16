--Script de criação do banco
DROP TABLE IF EXISTS Usuarios;
DROP TABLE IF EXISTS Tarifas;
DROP TABLE IF EXISTS Planos;

CREATE TABLE Planos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(50) NOT NULL,
    MinutosFranquia INT NOT NULL
);
GO

CREATE TABLE Tarifas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DddOrigem CHAR(3) NOT NULL,
    DddDestino CHAR(3) NOT NULL,
    ValorPorMinuto DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SenhaHash NVARCHAR(255) NOT NULL,
    Ativo BIT NOT NULL,
    Perfil NVARCHAR(20) NOT NULL,
    PlanoId INT NULL,
    FOREIGN KEY (PlanoId) REFERENCES Planos(Id)
);
GO

INSERT INTO Planos (Nome, MinutosFranquia) VALUES
('FaleMais 30', 30),
('FaleMais 60', 60),
('FaleMais 120', 120);
GO

INSERT INTO Tarifas (DddOrigem, DddDestino, ValorPorMinuto) VALUES
('011', '016', 1.90),
('016', '011', 2.90),
('011', '017', 1.70),
('017', '011', 2.70),
('011', '018', 0.90),
('018', '011', 1.90);
GO
