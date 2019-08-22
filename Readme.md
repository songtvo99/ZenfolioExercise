# Test on Zenfolio

## Zenfolio
Candidate Coding Project

## Assumptions
The decimal follow us culture and no hex number. It means: 1.2345
The mode is only number repeated larger other. 
It means we have sequence numbers: 1 1 2 2 3 4 5. The mode value is 1 and 2.
The case sensitive value 'A' and 'a' is two values
The Range value is maxValue - minValue. 
So, when we have negative values we till using negative to calculate. E.g: 1 2 3 -1 99 --> Range is 99 -(-1) = 100;

## Project Specifications

Create a command line application that takes in a user input.
After
the input the application will display the result and prompt the user for a new input.
The application will only exit with the word "quit".
The user input will be either a numerical sequence or a literal string.

With a numerical sequence input please find the mean, median, mode, and range.
Spaces
are the delimiter.
example
input = "1 2 3 4 5 6 7"
output:
mean = 4
median = 4
mode = none
range = 6

With a literal string please count the occurrence of each character and display it in alphabetical order. Spaces and special characters will be ignored.
example:
input:
"thisis a samplestring"
output:
a: 2 e: 1 g: 1 h:1 i:3 l:1 m:1 n:1 p:1 r:1 s:4 t:2

Please use a free online git repository that we can access to review your code.
Please make sure to have a .ignore file and a readme.

## Sample Test Cases

"1 2 13 45 99 0 0 0 1"
"0"
"sunsoutgunsout"
"quit
quit"
"I am n0thing m0r3 than a string. I t00 hav3 a l3xic0graphic 0rd3r."

## Optional Specs
Add the ability to handle negative and decimal numbers 
Add the ability to handle special characters and case sensitivity
Add unit tests

