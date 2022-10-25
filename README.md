## EJEMPLO DE USO DE FUNCIONES CLR PARA SQL SERVER

### _Manuel Toscano Blancas_

#### Activar CLR
sp_configure 'clr enabled', 1

GO

RECONFIGURE

GO

#### Permitir a la base de datos utilizar ensamblados
ALTER DATABASE NombreBaseDatos SET TRUSTWORTHY ON


#### Crear acceso a función del ensamblado
CREATE ASSEMBLY NombreEnsamblado

FROM 'Ruta_Hacia_DLL'

WITH PERMISSION_SET = EXTERNAL_ACCESS

#### Actualizar acceso a función del ensamblado si se modifica la DLL
ALTER ASSEMBLY NombreEnsamblado 
FROM 'Ruta_Hacia_DLL'

#### Consultar ensamblados
SELECT * FROM sys.assemblies

#### Crear función SQL con acceso al ensamblado (función CLR)
CREATE FUNCTION [dbo].[fnMiFuncion](@Parametro1 nvarchar(255))

RETURNS nvarchar(max) WITH EXECUTE AS CALLER

AS

EXTERNAL NAME NombreEnsamblado.NombreClase.NombreFuncion


#### Para procedimientos almacenados
CREATE PROCEDURE [dbo].[spMiProcedimiento]

@Parametro nvarchar(MAX)

WITH EXECUTE AS CALLER

AS EXTERNAL NAME NombreEnsamblado.NombreClase.NombreFuncion
