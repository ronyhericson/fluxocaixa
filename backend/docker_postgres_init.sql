/* ::: CRIAÇÂO DAS BASES DE DADOS */

CREATE DATABASE fluxocaixa
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;


/* ::: CRIAÇÃO DAS ESTRUTURAS DA BASE */	

\c fluxocaixa


/* CONFIGURANDO O TIME ZONE */
SET TIMEZONE TO 'America/Sao_Paulo';


/* EXTENSOES */

CREATE EXTENSION IF NOT EXISTS pgcrypto;

/* .:: INICIO ::. TABLES */


