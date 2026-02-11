CREATE TABLE public.cadastro (
  id serial NOT NULL,
  campo_texto character varying(30) NOT NULL,
  campo_numerico integer NOT NULL,
  CONSTRAINT cadastro_campo_numerico_key UNIQUE (campo_numerico),
  CONSTRAINT chk_numero_positivo CHECK (campo_numerico > 0)
);


CREATE TABLE
  public.log_auditoria (
    id serial NOT NULL,
    data_hora timestamp without time zone NULL DEFAULT CURRENT_TIMESTAMP,
    operacao character varying(20) NULL,
    id_registro_afetado integer NULL
  );

ALTER TABLE
  public.log_auditoria
ADD
  CONSTRAINT log_auditoria_pkey PRIMARY KEY (id)




CREATE OR REPLACE FUNCTION public.gerar_log_auditoria () 
RETURNS trigger LANGUAGE plpgsql AS $function$
BEGIN
    IF (TG_OP = 'INSERT') THEN
        INSERT INTO public.log_auditoria (operacao, id_registro_afetado)
        VALUES ('INSERT', NEW.id);
    ELSIF (TG_OP = 'UPDATE') THEN
        INSERT INTO public.log_auditoria (operacao, id_registro_afetado)
        VALUES ('UPDATE', NEW.id);
    ELSIF (TG_OP = 'DELETE') THEN
        INSERT INTO public.log_auditoria (operacao, id_registro_afetado)
        VALUES ('DELETE', OLD.id);
    END IF;
    RETURN NULL;
END;
$function$;


CREATE TRIGGER trg_gerar_auditoria
AFTER INSERT OR UPDATE OR DELETE ON public.cadastro
FOR EACH ROW EXECUTE FUNCTION public.gerar_log_auditoria();


TRUNCATE TABLE public.cadastro, public.log_auditoria RESTART IDENTITY;