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

DROP SEQUENCE IF EXISTS fluxocaixa_id_seq;
CREATE SEQUENCE fluxocaixa_id_seq
					 INCREMENT 1
					 MINVALUE 1
					 MAXVALUE 9223372036854775807
					 START 1
					 CACHE 1;

 CREATE TABLE IF NOT EXISTS fluxocaixa
 (
	id int not null DEFAULT nextval('fluxocaixa_id_seq'::regclass),
	dt_movimento timestamp,
	tp_movimento varchar(100),
	descricao varchar(500),
	vl_movimento numeric(14,2),
	vl_saldoatual numeric(14,2),
	constraint pk_fluxocaixa_id primary key (id)	
 )