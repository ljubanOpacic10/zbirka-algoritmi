# VALIDATION CHECKLIST

Before accepting LaTeX output, verify:

## STRUCTURE
- [ ] \rok exists
- [ ] Exactly 3 \zadatak blocks
- [ ] \sablon exists

## LANGUAGE
- [ ] Serbian Cyrillic only
- [ ] No mixed scripts

## TASKS
- [ ] Each task has title
- [ ] Description present
- [ ] Requirements in itemize
- [ ] Signatures inside Verbatim
- [ ] Examples included

## CONSISTENCY
- [ ] No invented content
- [ ] Method signatures unchanged
- [ ] Complexity preserved if present

## LATEX VALIDITY
- [ ] No broken environments
- [ ] Proper {} balancing

## FILE STRUCTURE
- [ ] File name matches folder structure
- [ ] Path in \sablon is correct

## STRUCTURE (EXTENDED)
- [ ] \zadatak uses correct 2-argument format
- [ ] No task numbers inside \zadatak

## CONTENT VALIDITY
- [ ] No invented sentences
- [ ] No explanations not present in PDF

## OPTIONAL CONTENT
- [ ] "Примери" exists ONLY if present in PDF

---

If ANY check fails → fix before committing.
