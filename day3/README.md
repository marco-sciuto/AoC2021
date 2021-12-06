The script simply count number of 0 and 1 in the provided file column by column.

---

For first part I used:
```
./puzzle3.sh < puzzle
```
Then followed instructions to obtain requested digits.

---

For the second part I used the same script using a regexp to filter input, digit by digit, following puzzle instructions.
```
grep -E ^0 puzzle | ./puzzle3.sh
grep -E ^01 puzzle | ./puzzle3.sh
...
```
then obtain partial result with:
```
grep -E ^010000100 puzzle
```
