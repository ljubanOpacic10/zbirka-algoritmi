# VALIDATION CHECKLIST

Before accepting LaTeX output, verify:

## STRUCTURE
- [ ] \rok exists
- [ ] Exactly 3 \zadatak blocks
- [ ] \sablon exists

## LANGUAGE
- [ ] Serbian Cyrillic only in prose
- [ ] No unnecessary mixed scripts
- [ ] English remains only where appropriate (algorithm names, code identifiers, class/method names, explicit technical terms)

## TASKS
- [ ] Each task has title
- [ ] Description is present
- [ ] Requirements are inside itemize if they exist
- [ ] Signatures are inside Verbatim if they exist
- [ ] Examples are included if present in PDF

## CONSISTENCY
- [ ] No invented content
- [ ] Method signatures unchanged semantically
- [ ] Complexity preserved if present
- [ ] Captions preserved if present
- [ ] Example order preserved

## LATEX VALIDITY
- [ ] No broken environments
- [ ] Proper {} balancing
- [ ] All environments are closed
- [ ] No obvious Overleaf-breaking syntax
- [ ] No content escaped incorrectly

## FILE STRUCTURE
- [ ] File name matches folder structure
- [ ] Path in \sablon is correct

## STRUCTURE (EXTENDED)
- [ ] \zadatak uses correct 2-argument format
- [ ] No task numbers inside \zadatak
- [ ] All task content is inside the second argument
- [ ] There are no orphaned paragraphs outside a task block

## CONTENT VALIDITY
- [ ] No invented sentences
- [ ] No explanations not present in PDF
- [ ] No fake placeholders in final content
- [ ] No "missing examples" filler text added by the agent

## OPTIONAL CONTENT
- [ ] "Примери" exists ONLY if present in PDF
- [ ] No optional section is added unless justified by the source

## SIGNATURE VALIDATION
- [ ] PDF line-wrap artifacts were removed from signatures only when needed
- [ ] No identifier is broken by accidental spaces
- [ ] No signature was semantically changed
- [ ] Parameter order matches the source
- [ ] Visibility and return type match the source

## KNOWN BST IMAGE VALIDATION
- [ ] If PDF contains known BST image 1, the predefined LaTeX tree code for image 1 is used
- [ ] If PDF contains known BST image 2, the predefined LaTeX tree code for image 2 is used
- [ ] \includegraphics is NOT used for known BST image 1 or known BST image 2
- [ ] The tree root value matches the expected known image
- [ ] Parent-child relationships match the expected known image
- [ ] Phantom nodes are preserved where required
- [ ] Caption formatting matches project examples

## GENERIC IMAGE VALIDATION
- [ ] If the image is NOT one of the two known BST images, generic image handling rules are used
- [ ] If generic image handling is used, image paths are valid
- [ ] If generic image handling is used, captions are preserved if present
- [ ] Each non-known image from PDF is rendered exactly once

## EXAMPLE VALIDATION
- [ ] Example labels use Serbian Cyrillic (`Улаз`, `Излаз`, `Слика`, `Корак`)
- [ ] Example numbering matches the source PDF
- [ ] Multi-example tasks preserve all examples from the PDF
- [ ] Image/example ordering matches the source

## OVERLEAF SAFETY CHECKS
- [ ] No unsupported environment is introduced without project support
- [ ] No missing package-dependent syntax is used accidentally
- [ ] All opened environments are closed in the same task block
- [ ] No inconsistent image strategy is used
- [ ] No project-incompatible \sablon line is generated

## TEMPLATE LINE VALIDATION
- [ ] \sablon first argument matches project naming convention
- [ ] \sablon second argument points to the correct `.linq` file

---

If ANY check fails → fix before committing.