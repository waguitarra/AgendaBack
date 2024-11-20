# -*- coding: iso-8859-1 -*-
import mysql.connector
import sys

# Extrai informações dos parâmetros
timestamp = sys.argv[1] + " " + sys.argv[2]
level = sys.argv[3]
callsite = sys.argv[4]
parameterName = sys.argv[5]
# Concatena os argumentos existentes de 6 até 10 (ou até o último argumento recebido)
message = " ".join([arg for arg in sys.argv[6:11] if arg])

# Imprime os valores dos parâmetros
print("Argumentos recebidos:")
print("Timestamp:", timestamp)
print("Level:", level)
print("Callsite:", callsite)
print("ParameterName:", parameterName)
print("Message:", message)

# Configura a conexão com a base de dados
config = {
    'user': 'semente',
    'password': 'w@g3691715Figueiredo',
    'host': 'localhost',
    'database': 'TrocaSementes'
}
cnx = mysql.connector.connect(**config)
cursor = cnx.cursor()

# Insere os dados do log na base de dados
add_log = ("INSERT INTO logs "
           "(Date, Level, Callsite, ParameterName, Message) "
           "VALUES (%s, %s, %s, %s, %s)")
log_data = (timestamp, level, callsite, parameterName, message)
cursor.execute(add_log, log_data)

# Commita as mudanças
cnx.commit()

# Fecha a conexão com a base de dados
cursor.close()
cnx.close()
