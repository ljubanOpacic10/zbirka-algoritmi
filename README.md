# Zbirka Algoritmi

Repozitorijum za pripremu i održavanje zbirke zadataka iz predmeta **Algoritmi i strukture podataka**.

Glavni cilj projekta je da se zadaci sa testova organizuju po rokovima i grupama, a zatim dosledno pretvaraju u LaTeX sadržaj koji može direktno da se koristi u glavnom dokumentu zbirke.

## Šta se nalazi u projektu

- `AISP_ZBIRKA_2026/`: glavni LaTeX projekat zbirke.
- `AISP_ZBIRKA_2026/2025/...`: testovi organizovani po mesecu i grupi.
- `AISP_ZBIRKA_2026/AISPBiblioteka/`: biblioteka komponenti i uvodni sadržaj.
- `AI_RULES/`: pravila za AI pipeline (ekstrakcija -> generisanje -> validacija).

## AI_RULES: kako se koristi

Folder `AI_RULES/` definiše obavezan redosled rada kada se iz PDF testa generiše LaTeX fajl.

### 1) Ekstrakcija iz PDF-a

Koristi se: `AI_RULES/01_EXTRACTION_RULES.md`

Ulaz:
- PDF testa

Izlaz:
- strogo strukturisan JSON sa opštim podacima i tačno 3 zadatka

Važno:
- ne prevoditi,
- ne sažimati,
- ne popravljati potpise metoda,
- ignorisati studentska uputstva i ponavljajuće header/footer delove.

### 2) Transformacija JSON -> LaTeX

Koristi se: `AI_RULES/02_LATEX_GENERATION_RULES.md`

Ulaz:
- JSON iz koraka 1

Izlaz:
- LaTeX sadržaj (nije standalone dokument)

Važno:
- koristiti srpsku ćirilicu,
- pratiti tačan format `\rok`, `\zadatak`, `\sablon`,
- tačno 3 zadatka,
- ne izmišljati sadržaj,
- sekciju "Примери" uključiti samo ako postoji u originalu.

### 3) Validacija izlaza

Koristi se: `AI_RULES/03_VALIDATION_CHECKLIST.md`

Ulaz:
- LaTeX iz koraka 2

Izlaz:
- PASS / FAIL + lista problema

Ako je FAIL:
- ispraviti samo problematične delove,
- ponoviti validaciju dok ne postane PASS.

### 4) Orkestracija celog procesa

Koristi se: `AI_RULES/04_ORCHESTRATION_AGENT.md`

Ovaj dokument je "kontroler" celog pipeline-a i propisuje:
- obavezan redosled koraka,
- zabranu preskakanja faza,
- obaveznu validaciju pre finalnog izlaza,
- ažuriranje `main.tex` nakon dodavanja novih fajlova.

## Preporučeni workflow za dodavanje novog testa

1. Dodaj PDF izvornog testa (lokalno ili u radni direktorijum za obradu).
2. Primeni pravila iz `01_EXTRACTION_RULES.md` i dobij JSON.
3. Primeni `02_LATEX_GENERATION_RULES.md` i generiši `.tex` fajl.
4. Proveri prema `03_VALIDATION_CHECKLIST.md`.
5. Snimi rezultat u odgovarajući folder, npr. `AISP_ZBIRKA_2026/2025/<Mesec>/<Grupa>/`.
6. Dodaj ili ažuriraj `\input{...}` stavku u `AISP_ZBIRKA_2026/main.tex`.
7. Kompajliraj dokument i proveri da nema LaTeX grešaka.

## Kompajliranje zbirke

Iz foldera `AISP_ZBIRKA_2026/` može se koristiti standardni LaTeX build (npr. u Overleaf-u ili lokalno):

```bash
pdflatex main.tex
```

Po potrebi pokrenuti više prolaza da se osveže sadržaj i reference.

## Napomene o konzistentnosti

- Imena fajlova treba da prate postojeću šemu po mesecu, testu i grupi.
- Putanja u `\sablon{...}{...}` mora biti tačna i relativna.
- Ne unositi sadržaj koji ne postoji u izvornom testu.

## Zašto ovaj pristup

Striktna pravila u `AI_RULES/` obezbeđuju:
- ujednačen stil kroz celu zbirku,
- manje ručnih grešaka,
- brže dodavanje novih rokova,
- LaTeX izlaz spreman za direktno uključivanje u glavni dokument.
