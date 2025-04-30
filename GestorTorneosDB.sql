-- 1) Crear la base de datos
CREATE DATABASE GestorTorneos;
GO

USE GestorTorneos;
GO

-- 2) Tabla de jugadores
CREATE TABLE Jugadores (
    IdJugador       INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre          NVARCHAR(100)      NOT NULL,
    Puntuacion      INT                NOT NULL DEFAULT 0
);
GO

CREATE TABLE Estados(
	IdEstado			INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Estado				VARCHAR(20)		  NOT NULL
);

-- 3) Tabla de inscripciones (cola + lista de espera)
CREATE TABLE Inscripciones (
    IdInscripcion      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdJugador          INT               NOT NULL,
    FechaInscripcion   DATETIME          NOT NULL DEFAULT GETDATE(),
    IdEstado		   INT				 NOT NULL,
	CONSTRAINT IdJugadorInscripcion FOREIGN KEY (IdJugador) REFERENCES Jugadores(IdJugador),
    CONSTRAINT IdEstadoInscripcion  FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
);
GO

-- 4) Tabla de partidos (nodos del árbol)
CREATE TABLE Partidos (
    IdPartido       INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdJugador1      INT               NOT NULL,
    IdJugador2      INT               NOT NULL,
    IdGanador       INT               NULL,
    NumeroRonda     INT               NOT NULL,
    IdPartidoPadre  INT               NULL,
    CONSTRAINT IdJugador1		FOREIGN KEY (IdJugador1)      REFERENCES Jugadores(IdJugador),
    CONSTRAINT IdJugador2		FOREIGN KEY (IdJugador2)      REFERENCES Jugadores(IdJugador),
    CONSTRAINT IdGanador		FOREIGN KEY (IdGanador)       REFERENCES Jugadores(IdJugador),
    CONSTRAINT IdPartidoPadre	FOREIGN KEY (IdPartidoPadre)  REFERENCES Partidos(IdPartido)
);

CREATE TABLE Torneos(
	IdTorneo		INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Rondas			INT				  NOT NULL,
	IdGanador			INT				  NOT NULL,
	CONSTRAINT IdGanadorTorneo	FOREIGN KEY (IdGanador)		REFERENCES Jugadores(IdJugador)
);
GO

INSERT INTO Estados (Estado) VALUES 
('Pendiente'),      -- Estado 1: Jugador en cola principal
('En espera'),      -- Estado 2: Jugador en lista de espera
('Confirmado'),     -- Estado 3: Jugador confirmado para torneo
('Cancelado'),      -- Estado 4: Inscripción cancelada
('Completado');     -- Estado 5: Torneo completado
GO