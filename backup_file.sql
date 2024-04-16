--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: is_album_type(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.is_album_type(type_value text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value IN ('album');
END;
$$;


ALTER FUNCTION public.is_album_type(type_value text) OWNER TO postgres;

--
-- Name: is_comic_type(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.is_comic_type(type_value text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value IN ('comic');
END;
$$;


ALTER FUNCTION public.is_comic_type(type_value text) OWNER TO postgres;

--
-- Name: is_single_type(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.is_single_type(type_value text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value IN ('single');
END;
$$;


ALTER FUNCTION public.is_single_type(type_value text) OWNER TO postgres;

--
-- Name: is_threed_type(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.is_threed_type(type_value text) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value IN ('threed');
END;
$$;


ALTER FUNCTION public.is_threed_type(type_value text) OWNER TO postgres;

--
-- Name: require_albumid_for_albums(text, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.require_albumid_for_albums(type_value text, album_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value = 'album' AND album_id IS NOT NULL;
END;
$$;


ALTER FUNCTION public.require_albumid_for_albums(type_value text, album_id integer) OWNER TO postgres;

--
-- Name: require_id_for_type(text, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.require_id_for_type(type_value text, id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN 
    (type_value = 'comic' AND id IS NOT NULL) OR
    (type_value = 'threed' AND id IS NOT NULL) OR
    (type_value = 'album' AND id IS NOT NULL) OR
    (type_value = 'single' AND id IS NOT NULL) OR
    (type_value = 'music video' AND id IS NOT NULL);
END;
$$;


ALTER FUNCTION public.require_id_for_type(type_value text, id integer) OWNER TO postgres;

--
-- Name: require_singleid_and_albumid_for_singles(text, integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.require_singleid_and_albumid_for_singles(type_value text, single_id integer, album_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN type_value = 'single' AND single_id IS NOT NULL AND album_id IS NOT NULL;
END;
$$;


ALTER FUNCTION public.require_singleid_and_albumid_for_singles(type_value text, single_id integer, album_id integer) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: albums; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.albums (
    albumid integer NOT NULL,
    title character varying(255) NOT NULL,
    artist character varying(255) NOT NULL,
    releasedate date,
    tracks integer
);


ALTER TABLE public.albums OWNER TO postgres;

--
-- Name: artist; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.artist (
    artistid integer NOT NULL,
    name character varying(255) NOT NULL,
    stagename character varying(50) NOT NULL,
    birthday date,
    hometown character varying(50) NOT NULL,
    occupation character varying(255) NOT NULL,
    styleofmusic character varying(50) NOT NULL,
    totalsongs integer,
    film_participated character varying(50)
);


ALTER TABLE public.artist OWNER TO postgres;

--
-- Name: chapters; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.chapters (
    chapterid integer NOT NULL,
    comicid integer,
    title character varying(255) NOT NULL,
    chapternumber integer,
    releasedate date,
    content text
);


ALTER TABLE public.chapters OWNER TO postgres;

--
-- Name: comics; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comics (
    comicid integer NOT NULL,
    title character varying(255) NOT NULL,
    author character varying(255) NOT NULL,
    releasedate date,
    genre character varying(100),
    description text
);


ALTER TABLE public.comics OWNER TO postgres;

--
-- Name: musicvideos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.musicvideos (
    musicvideoid integer NOT NULL,
    title character varying(255) NOT NULL,
    artist character varying(255) NOT NULL,
    releasedate date
);


ALTER TABLE public.musicvideos OWNER TO postgres;

--
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    productid integer NOT NULL,
    name character varying(255) NOT NULL,
    type character varying(20) NOT NULL,
    price numeric(10,2) NOT NULL,
    comicid integer,
    threedid integer,
    albumid integer,
    singleid integer,
    musicvideoid integer,
    CONSTRAINT require_id_for_type_check CHECK ((public.require_id_for_type((type)::text, comicid) OR public.require_id_for_type((type)::text, threedid) OR public.require_id_for_type((type)::text, albumid) OR public.require_id_for_type((type)::text, singleid) OR public.require_id_for_type((type)::text, musicvideoid)))
);


ALTER TABLE public.product OWNER TO postgres;

--
-- Name: singles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.singles (
    singleid integer NOT NULL,
    title character varying(255) NOT NULL,
    artist character varying(255) NOT NULL,
    releasedate date,
    genre character varying(100),
    albumid integer
);


ALTER TABLE public.singles OWNER TO postgres;

--
-- Name: threed; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.threed (
    threedid integer NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE public.threed OWNER TO postgres;

--
-- Data for Name: albums; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.albums (albumid, title, artist, releasedate, tracks) FROM stdin;
1	tram cam xuc	1989s	2021-05-01	\N
2	dramatic	bich phuong	2018-11-01	\N
3	chi la em giau di	bich phuong	2013-11-02	5
4	tam trang tan hoi cham mot chut	Bich Phuong	2020-06-18	\N
5	ve ben em di	Bich Phuong	2019-08-24	\N
6	emily summer time	BigDadddy	2019-07-27	\N
7	muon ruou to tinh	BigDadddy	2019-06-14	\N
8	tam su voi nguoi la	Tien Cookie	2015-12-24	\N
9	gui anh xa nho	Bich Phuong	2015-11-03	\N
10	khoi thuoc doi cho	Bich Phuong	2022-01-01	30
11	sau tat ca	Tien Cookie	2014-11-26	30
\.


--
-- Data for Name: artist; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.artist (artistid, name, stagename, birthday, hometown, occupation, styleofmusic, totalsongs, film_participated) FROM stdin;
1	Nguyen Thanh Tung	son tung mtp	1994-07-05	Thai Binh	singer,actor,composer	R&B,pop ballad	20	dandelion
2	Bui Thi Bich Phuong	Bich Phuong	1989-09-30	Quang Ninh	singer,songwriter	v-pop	50	0
3	Truong Anh Phuc	Phuc Du	1996-12-25	Ha Noi	rapper,songwriter	Rap	50	0
4	Tran Tat Vu	BigDaddy	1991-08-05	Ha Noi	rapper,songwriter	Rap	60	0
5	Nguyen Thuy Tien	Tien Cookie	1994-02-26	Ha Noi	singer,songwriter,composer	\tpop, R&B,ballads	40	0
\.


--
-- Data for Name: chapters; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.chapters (chapterid, comicid, title, chapternumber, releasedate, content) FROM stdin;
101	1	Chapter 1	1	2011-04-01	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
102	1	Chapter 2	2	2011-04-08	kokokkokkkokokoko
103	1	Chapter 3	3	2011-04-15	kokokkokkkokokoko
104	1	Chapter 4	4	2011-04-22	kokokkokkkokokoko
201	2	ep 1	1	2022-12-11	aaaaaaaaa
202	2	ep 2	2	2022-12-18	aaaaaaaaa
203	2	ep 3	3	2022-12-25	aaaaaaaaa
204	2	ep 4	4	2023-01-01	aaaaaaaaa
205	2	ep 5	5	2022-01-08	aaaaaaaaa
206	2	ep 6	6	2022-01-15	aaaaaaaaa
207	2	ep 7	7	2022-01-22	aaaaaaaaa
208	2	ep 8	8	2022-01-29	aaaaaaaaa
209	2	ep 9	9	2022-02-05	aaaaaaaaa
210	2	ep 10	10	2022-02-12	aaaaaaaaa
211	2	ep 11	11	2022-02-19	aaaaaaaaa
301	3	1	1	2021-11-21	huhuhuhhu
302	3	2	2	2021-11-29	huhuhuhhu
303	3	3	3	2021-12-06	huhuhuhhu
304	3	4	4	2021-12-13	huhuhuhhu
305	3	5	5	2021-12-20	huhuhuhhu
306	3	6	6	2021-12-27	huuhuhhuh
307	3	7	7	2022-01-03	huuhuhhuh
308	3	8	8	2022-01-10	huuhuhhuh
309	3	9	9	2022-01-17	huuhuhhuh
310	3	10	10	2022-01-24	huuhuhhuh
311	3	11	11	2022-01-31	huuhuhhuh
312	3	12	12	2022-02-07	huuhuhhuh
313	3	13	13	2022-02-14	huuhuhhuh
314	3	14	14	2022-02-21	huuhuhhuh
315	3	15	15	2022-02-28	huuhuhhuh
316	3	16	16	2022-03-07	huuhuhhuh
317	3	17	17	2022-03-14	huuhuhhuh
318	3	18	18	2022-03-21	huuhuhhuh
401	4	tap 1-p1	1	2021-12-12	jiijjjijji
402	4	tap 2 p1	2	2020-11-07	lolololllo
403	4	tap 3 p1	3	2020-11-14	lolololllo
404	4	tap 4 p1	4	2020-11-21	lolololllo
405	4	tap 5 p1	5	2020-11-28	lolololllo
406	4	tap 6 p1	6	2020-12-05	lolololllo
407	4	tap 7 p1	7	2020-12-12	lolololllo
408	4	tap 8 p1	8	2020-12-19	lolololllo
409	4	tap 9 p1	9	2020-12-26	lolololllo
410	4	tap 10 p1	10	2020-12-31	lolololllo
411	4	tap 1 p2	1	2020-01-07	lolololllo
412	4	tap 2 p2	2	2020-01-14	lolololllo
413	4	tap 3 p2	3	2020-01-21	lolololllo
414	4	tap 4 p2	4	2020-01-28	lolololllo
415	4	tap 5 p2	5	2020-02-07	lolololllo
416	4	tap 6 p2	6	2020-02-14	lolololllo
417	4	tap 7 p2	7	2020-02-21	lolololllo
418	4	tap 8 p2	8	2020-02-28	lolololllo
419	4	tap 9 p2	9	2020-03-07	lolololllo
501	5	chap 1	1	2023-06-16	gygygygy
502	5	chap 2	2	2023-06-23	gygygygy
503	5	chap 3	3	2023-06-30	gygygygy
504	5	chap 4	4	2023-07-07	gygygygy
505	5	chap 5	5	2023-07-14	gygygygy
506	5	chap 6	6	2023-07-21	gygygygy
507	5	chap 7	7	2023-07-28	gygygygy
508	5	chap 8	8	2023-08-04	gygygygy
509	5	chap 9	9	2023-08-11	gygygygy
510	5	chap 10	10	2023-08-18	gygygygy
511	5	chap 11	11	2023-08-25	gygygygy
601	5	chap 1	1	2021-11-11	gygygygy
602	5	chap 2	2	2021-11-18	gygygygy
603	5	chap 3	3	2021-11-25	gygygygy
604	5	chap 4	4	2021-12-07	gygygygy
605	5	chap 5	5	2021-12-14	gygygygy
606	5	chap 6	6	2022-07-21	gygygygy
607	5	chap 7	7	2022-07-28	gygygygy
608	5	chap 8	8	2022-08-04	gygygygy
609	5	chap 9	9	2022-08-11	gygygygy
610	5	chap 10	10	2022-08-18	gygygygy
611	5	ngoai truyen 1	11	2022-08-25	gygygygy
612	5	ngoai truyen 2	12	2022-08-25	gygygygy
701	7	1	1	2019-12-12	okokkookko
702	7	2	2	2019-12-12	okokkookko
703	7	3	3	2019-12-12	okokkookko
704	7	4	4	2019-12-12	okokkookko
705	7	5	5	2019-12-12	okokkookko
706	7	6	6	2019-12-12	okokkookko
707	7	7	7	2019-12-12	okokkookko
708	7	8	8	2019-12-12	okokkookko
709	7	9	9	2019-12-12	okokkookko
710	7	10	10	2019-12-12	okokkookko
711	7	11	11	2019-12-12	okokkookko
712	7	12	12	2019-12-12	okokkookko
713	7	13	13	2019-12-12	okokkookko
714	7	14	14	2019-12-12	okokkookko
715	7	15	15	2019-12-12	okokkookko
716	7	16	16	2019-12-12	okokkookko
717	7	17	17	2019-12-12	okokkookko
718	7	18	18	2019-12-12	okokkookko
719	7	19	19	2019-12-12	okokkookko
720	7	20	20	2019-12-12	okokkookko
721	7	21	21	2019-12-12	okokkookko
722	7	22	22	2019-12-12	okokkookko
723	7	23	23	2019-12-12	okokkookko
724	7	24	24	2019-12-12	okokkookko
725	7	25	25	2019-12-12	okokkookko
726	7	26	26	2019-12-12	okokkookko
727	7	27	27	2019-12-12	okokkookko
728	7	28	28	2019-12-12	okokkookko
729	7	29	29	2019-12-12	okokkookko
730	7	30	30	2019-12-12	okokkookko
731	7	31	31	2019-12-12	okokkookko
732	7	32	32	2019-12-12	okokkookko
733	7	33	33	2019-12-12	okokkookko
734	7	34	34	2019-12-12	okokkookko
735	7	35	35	2019-12-12	okokkookko
736	7	36	36	2019-12-12	okokkookko
737	7	37	37	2019-12-12	okokkookko
738	7	38	38	2019-12-12	okokkookko
739	7	39	39	2019-12-19	okokkookko
740	7	40	40	2019-12-25	okokkookko
741	7	41	41	2019-12-26	okokkookko
742	7	42	42	2019-12-27	okokkookko
743	7	43	43	2019-12-28	okokkookko
744	7	44	44	2019-12-29	okokkookko
745	7	45	45	2020-01-25	okokkookko
746	7	46	46	2020-01-25	okokkookko
747	7	47	47	2020-02-25	okokkookko
748	7	48	48	2020-02-25	okokkookko
749	7	49	49	2020-02-27	okokkookko
750	7	50	50	2020-02-28	okokkookko
751	7	51	51	2020-03-02	okokkookko
752	7	52	52	2020-03-08	okokkookko
753	7	53	53	2020-03-28	okokkookko
754	7	54	54	2020-03-28	okokkookko
755	7	55	55	2020-03-28	okokkookko
756	7	56	56	2020-03-30	okokkookko
757	7	57	57	2020-03-31	okokkookko
758	7	58	58	2020-03-31	okokkookko
759	7	59	59	2020-03-31	okokkookko
760	7	60	60	2020-04-28	okokkookko
761	7	61	61	2020-04-30	okokkookko
762	7	62	62	2020-05-02	okokkookko
763	7	63	63	2020-05-08	okokkookko
764	7	64	64	2020-05-08	okokkookko
765	7	65	65	2020-05-08	okokkookko
766	7	66	66	2020-05-08	okokkookko
767	7	67	67	2020-05-18	okokkookko
768	7	68	68	2020-05-19	okokkookko
769	7	69	69	2020-05-22	okokkookko
770	7	70	70	2020-05-29	okokkookko
771	7	71	70	2020-05-31	okokkookko
772	7	72	70	2020-05-31	okokkookko
773	7	73	70	2020-06-09	okokkookko
774	7	74	70	2020-06-11	okokkookko
775	7	75	70	2020-06-19	okokkookko
776	7	76	70	2020-06-22	okokkookko
777	7	77	70	2020-06-29	okokkookko
778	7	78	70	2020-07-02	okokkookko
779	7	79	70	2020-07-03	okokkookko
780	7	80	80	2020-07-06	okokkookko
781	7	81	81	2020-07-09	okokkookko
782	7	82	82	2020-07-11	okokkookko
783	7	83	83	2020-07-12	okokkookko
784	7	84	84	2020-07-16	okokkookko
785	7	85	85	2020-07-26	okokkookko
786	7	86	86	2020-07-29	okokkookko
787	7	87	87	2020-07-31	okokkookko
788	7	88	88	2020-08-06	okokkookko
789	7	89	89	2020-08-09	okokkookko
790	7	90	90	2020-08-16	okokkookko
791	7	91	91	2020-08-21	okokkookko
792	7	92	92	2020-08-22	okokkookko
793	7	93	93	2020-08-26	okokkookko
794	7	94	94	2020-08-30	okokkookko
795	7	95	95	2020-08-31	okokkookko
796	7	96	96	2020-09-01	okokkookko
797	7	97	97	2020-09-06	okokkookko
798	7	98	98	2020-09-16	okokkookko
799	7	99	99	2020-09-21	okokkookko
7100	7	100	100	2020-09-26	okokkookko
7101	7	101	101	2020-10-02	okokkookko
7102	7	102	102	2020-10-06	okokkookko
7103	7	103	103	2020-10-13	okokkookko
7104	7	104	104	2020-10-19	okokkookko
7105	7	105	105	2020-10-26	okokkookko
7106	7	106	106	2020-10-29	okokkookko
7107	7	107	107	2020-10-31	okokkookko
7108	7	108	108	2021-09-26	okokkookko
7109	7	109	109	2022-09-26	okokkookko
7110	7	110	110	2023-09-26	okokkookko
7111	7	111	111	2023-12-11	okokkookko
801	8	1	1	2023-04-18	okokkookko
802	8	2	2	2023-04-18	okokkookko
803	8	3	3	2023-04-21	okokkookko
804	8	4	4	2023-04-28	okokkookko
805	8	5	5	2023-05-12	okokkookko
806	8	6	6	2023-05-13	okokkookko
807	8	7	7	2023-05-19	okokkookko
808	8	8	8	2023-05-22	okokkookko
809	8	9	9	2023-06-12	okokkookko
810	8	10	10	2023-06-17	okokkookko
811	8	11	11	2023-06-22	okokkookko
812	8	12	12	2023-06-22	okokkookko
813	8	13	13	2023-06-25	okokkookko
814	8	14	14	2023-06-29	okokkookko
815	8	15	15	2023-06-30	okokkookko
816	8	16	16	2023-07-12	okokkookko
817	8	17	17	2023-07-12	okokkookko
818	8	18	18	2023-07-17	okokkookko
819	8	19	19	2023-07-22	okokkookko
820	8	20	20	2023-07-25	okokkookko
821	8	21	21	2023-07-29	okokkookko
822	8	22	22	2023-07-31	okokkookko
823	8	23	23	2023-08-12	okokkookko
824	8	24	24	2023-08-19	okokkookko
825	8	25	25	2023-08-22	okokkookko
826	8	26	26	2023-08-29	okokkookko
827	8	27	27	2023-08-30	okokkookko
828	8	28	28	2023-08-31	okokkookko
829	8	29	29	2023-09-02	okokkookko
830	8	30	30	2023-09-07	okokkookko
831	8	31	31	2023-09-12	okokkookko
832	8	32	32	2023-09-12	okokkookko
833	8	33	33	2023-09-17	okokkookko
834	8	34	34	2023-09-21	okokkookko
835	8	35	35	2023-09-22	okokkookko
836	8	36	36	2023-09-22	okokkookko
837	8	37	37	2023-09-24	okokkookko
838	8	38	38	2023-09-12	okokkookko
839	8	39	39	2023-10-01	okokkookko
840	8	40	40	2023-10-02	okokkookko
841	8	41	41	2023-10-26	okokkookko
842	8	42	42	2023-10-27	okokkookko
843	8	43	43	2023-10-28	okokkookko
844	8	44	44	2023-11-29	okokkookko
845	8	45	45	2023-12-25	okokkookko
846	8	46	46	2023-12-29	okokkookko
847	8	47	47	2023-12-31	okokkookko
848	8	48	48	2024-02-25	okokkookko
849	8	49	49	2024-02-27	okokkookko
850	8	50	50	2024-02-28	okokkookko
851	8	51	51	2024-03-02	okokkookko
852	8	52	52	2024-03-08	okokkookko
853	8	53	53	2024-03-28	okokkookko
854	8	54-End	54	2024-03-31	okokkookko
901	9	chap 1	1	2012-10-10	okokkookko
902	9	chap 2	2	2023-04-18	okokkookko
903	9	chap 3	3	2023-04-21	okokkookko
904	9	chap 4	4	2023-04-28	okokkookko
905	9	chap 5	5	2023-05-12	okokkookko
906	9	chap 6	6	2023-05-13	okokkookko
907	9	chap 7	7	2023-05-19	okokkookko
908	9	chap 8	8	2023-05-22	okokkookko
1001	10	chap 1	1	2022-11-22	okokkookko
\.


--
-- Data for Name: comics; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comics (comicid, title, author, releasedate, genre, description) FROM stdin;
1	Lau Dai Man Ro	별보라	2010-12-13	Manhwa,Adult,Romance,Drama	aaaaaaaaaaa
2	Thieu Nien Ca Hanh	Chau Moc Nam	2022-12-11	hoat hinh	avabbbhjdsvcas
3	Hay Khoc va cau nguyen di	Solche	2021-11-21	Manhwa	jjhjhhjhhj
4	Thien quan tu phuc	Mac Huong Dong Xu	2020-10-31	hoat hinh	hay
5	Thieu gia khong ngoan	dang cap nhat	2023-06-16	manhwa	gay vl
6	Hoang phi cuu thien tue	子暖	2021-11-11	Romance	.....
7	khong muon ga cho cong tuoc cuong anh trai dau	dang cap nhat	2019-12-12	manhua	chchcch
8	vuong phi that uy vu	Trieu Y Lam	2023-04-18	manhua	nbjgkggk
9	that hinh dai toi	Suzuki Nakaba	2012-10-10	manga	hay vkl
10	trai tim co nang	Aikawa Fuu	2022-11-22	manga	looks very gay
\.


--
-- Data for Name: musicvideos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.musicvideos (musicvideoid, title, artist, releasedate) FROM stdin;
1	khi minh xinh thi minh lam gi	Bich Phuong	2018-05-12
2	o sao be khong lac	BigDaddy	2019-07-01
3	nguoi tinh nho be	BigDaddy	2019-06-11
4	muon game to tinh	BigDaddy	2019-04-30
5	muon ruou to tinh	BigDaddy	2019-02-12
6	chuyen cu bo qua	Bich Phuong	2018-12-12
\.


--
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product (productid, name, type, price, comicid, threedid, albumid, singleid, musicvideoid) FROM stdin;
1	Lau Dai Man Ro	comic	10.99	1	\N	\N	\N	\N
2	Thieu Nien Ca Hanh	comic	11.99	2	\N	\N	\N	\N
3	Hay khoc va cau nguyen di	comic	10.99	3	\N	\N	\N	\N
4	Thien quan tu phuc	comic	10.99	4	\N	\N	\N	\N
5	Thieu gia khong ngoan	comic	10.99	5	\N	\N	\N	\N
6	Hoang phi cuu thien tue	comic	10.99	6	\N	\N	\N	\N
7	khong muon ga cho cong tuoc cuong anh trai dau	comic	10.99	7	\N	\N	\N	\N
8	vuong phi that uy vu	comic	10.99	8	\N	\N	\N	\N
9	that hinh dai toi	comic	10.99	9	\N	\N	\N	\N
10	trai tim co nang	comic	10.99	10	\N	\N	\N	\N
11	item1	threed	15.99	\N	1	\N	\N	\N
12	item2	threed	15.99	\N	2	\N	\N	\N
13	item3	threed	15.99	\N	3	\N	\N	\N
14	item4	threed	15.99	\N	4	\N	\N	\N
15	item5	threed	15.99	\N	5	\N	\N	\N
16	item6	threed	15.99	\N	6	\N	\N	\N
17	item7	threed	15.99	\N	7	\N	\N	\N
18	item8	threed	15.99	\N	8	\N	\N	\N
19	item9	threed	15.99	\N	9	\N	\N	\N
20	item10	threed	15.99	\N	10	\N	\N	\N
21	item11	threed	15.99	\N	11	\N	\N	\N
22	item12	threed	15.99	\N	12	\N	\N	\N
23	item13	threed	15.99	\N	13	\N	\N	\N
24	item14	threed	15.99	\N	14	\N	\N	\N
25	item15	threed	15.99	\N	15	\N	\N	\N
26	tram cam xuc	album	12.99	\N	\N	1	\N	\N
27	dramatic	album	12.99	\N	\N	2	\N	\N
28	chi la em giau di	album	12.99	\N	\N	3	\N	\N
29	tam trang tan hoi cham mot chut	album	12.99	\N	\N	4	\N	\N
30	ve ben em di	album	12.99	\N	\N	5	\N	\N
31	emily summer time	album	12.99	\N	\N	6	\N	\N
32	muon ruou to tinh	album	12.99	\N	\N	7	\N	\N
33	tam su voi nguoi la	album	12.99	\N	\N	8	\N	\N
34	gui anh xa nho	album	12.99	\N	\N	9	\N	\N
35	khoi thuoc doi cho	album	12.99	\N	\N	10	\N	\N
36	sau tat ca	album	12.99	\N	\N	11	\N	\N
37	tu choi nhe nhang thoi	single	1.99	\N	\N	4	401	\N
38	thuong thuc noi buon	single	1.99	\N	\N	1	101	\N
39	me ly	single	1.99	\N	\N	1	102	\N
40	tuoi gi ma chang thich li xi	single	1.99	\N	\N	1	103	\N
41	di du dua di	single	1.99	\N	\N	5	501	\N
42	o sao be khong lac	single	1.99	\N	\N	6	601	\N
43	anh bo hut thuoc chua	single	1.99	\N	\N	1	104	\N
44	nguoi tinh nho be	single	1.99	\N	\N	7	701	\N
45	tam su voi nguoi la	single	1.99	\N	\N	8	801	\N
46	danh rang anh mai o ben	single	1.99	\N	\N	4	401	\N
47	sau trong em	single	1.99	\N	\N	10	1001	\N
48	minh yeu nhau di	single	1.99	\N	\N	10	1002	\N
49	chi la em giau di	single	1.99	\N	\N	10	1003	\N
50	vang anh di di	single	1.99	\N	\N	10	1004	\N
51	em muon	single	1.99	\N	\N	3	301	\N
52	sau tat ca	single	1.99	\N	\N	11	1101	\N
53	khi minh xinh thi minh lam gi	music video	16.69	\N	\N	\N	\N	1
54	o sao be khong lac	music video	16.69	\N	\N	\N	\N	2
55	nguoi tinh nho be	music video	16.69	\N	\N	\N	\N	3
56	muon game to tinh	music video	16.69	\N	\N	\N	\N	4
57	muon ruou to tinh	music video	16.69	\N	\N	\N	\N	5
58	chuyen cu bo qua	music video	16.69	\N	\N	\N	\N	6
\.


--
-- Data for Name: singles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.singles (singleid, title, artist, releasedate, genre, albumid) FROM stdin;
401	tu choi nhe nhang thoi	Bich Phuong	2020-06-06	Pop	4
101	thuong thuc noi buon	Tien Cookie	2021-05-12	Pop/R&B	1
102	me ly	BigDaddy	2020-10-12	Rap	1
103	tuoi gi ma chang thich li xi	Bich Phuong	2020-01-01	Pop	1
501	di du dua di	Bich Phuong	2019-08-24	disco	5
601	o sao be khong lac	BigDaddy	2019-07-27	rap	6
104	anh bo hut thuoc chua	Tien Cookie	2019-06-22	R&B	1
701	nguoi tinh nho be	BigDaddy	2019-06-14	rap	7
801	tam su voi nguoi la	Tien Cookie	2015-12-24	R&B	8
901	danh rang anh mai o ben	Bich Phuong	2015-11-03	Pop	9
1001	sau trong em	Bich Phuong	2015-04-01	vpop	10
1002	minh yeu nhau di	Bich Phuong	2014-02-02	vpop	10
1003	chi la em giau di	Bich Phuong	2013-06-01	pop	10
1004	vang anh di di	Bich Phuong	2013-06-01	vpop	10
301	em muon	Bich Phuong	2013-06-01	vpop	3
1101	sau tat ca	Tien Cookie	2013-05-01	R&B	11
\.


--
-- Data for Name: threed; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.threed (threedid, name) FROM stdin;
1	item1
2	item2
3	item3
4	item4
5	item5
6	item6
7	item7
8	item8
9	item9
10	item10
11	item11
12	item12
13	item13
14	item14
15	item15
\.


--
-- Name: albums albums_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.albums
    ADD CONSTRAINT albums_pkey PRIMARY KEY (albumid);


--
-- Name: artist artist_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.artist
    ADD CONSTRAINT artist_pkey PRIMARY KEY (artistid);


--
-- Name: chapters chapters_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chapters
    ADD CONSTRAINT chapters_pkey PRIMARY KEY (chapterid);


--
-- Name: comics comics_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comics
    ADD CONSTRAINT comics_pkey PRIMARY KEY (comicid);


--
-- Name: musicvideos musicvideos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musicvideos
    ADD CONSTRAINT musicvideos_pkey PRIMARY KEY (musicvideoid);


--
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (productid);


--
-- Name: singles singles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.singles
    ADD CONSTRAINT singles_pkey PRIMARY KEY (singleid);


--
-- Name: threed threed_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.threed
    ADD CONSTRAINT threed_pkey PRIMARY KEY (threedid);


--
-- Name: artist unique_stagename; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.artist
    ADD CONSTRAINT unique_stagename UNIQUE (stagename);


--
-- Name: chapters chapters_comicid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chapters
    ADD CONSTRAINT chapters_comicid_fkey FOREIGN KEY (comicid) REFERENCES public.comics(comicid);


--
-- Name: musicvideos fk_artist_stagename; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musicvideos
    ADD CONSTRAINT fk_artist_stagename FOREIGN KEY (artist) REFERENCES public.artist(stagename);


--
-- Name: product product_albumid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_albumid_fkey FOREIGN KEY (albumid) REFERENCES public.albums(albumid);


--
-- Name: product product_comicid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_comicid_fkey FOREIGN KEY (comicid) REFERENCES public.comics(comicid);


--
-- Name: product product_musicvideoid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_musicvideoid_fkey FOREIGN KEY (musicvideoid) REFERENCES public.musicvideos(musicvideoid);


--
-- Name: product product_singleid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_singleid_fkey FOREIGN KEY (singleid) REFERENCES public.singles(singleid);


--
-- Name: product product_threedid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_threedid_fkey FOREIGN KEY (threedid) REFERENCES public.threed(threedid);


--
-- Name: singles singles_albumid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.singles
    ADD CONSTRAINT singles_albumid_fkey FOREIGN KEY (albumid) REFERENCES public.albums(albumid);


--
-- PostgreSQL database dump complete
--

