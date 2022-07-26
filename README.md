# Kata console app

## About

A console application that prints katas based on arg input of any letter of the alphabet based on an uppercase diamond format form

## Usage

Example execution from a console or PowerShell (with the letter 'd' as the arg):

```dotnet
> Kata.ConsoleApp.exe d
   A  
  B B
 C   C
D     D
 C   C
  B B
   A
```

## Problem Statement

https://github.com/davidwhitney/CodeDojos/blob/master/Diamond%20Kata/readme.md

## Solution Structure

###### Kata.ConsoleApp
Console app that can be executed from the Command Prompt or Windows PowerShell

###### Kata.Core 
Shared libraries with a built in diamond form provider used by Kata.ConsoleApp

###### Kata.Core.Tests
Unit tests covering Kata.Core

###### Extras
`DiamondFormProvider pattern.xlsx` that describes the built in diamond format form

## Author

Daniel Kerri 

- LinkedIn - https://uk.linkedin.com/in/danielkerri
- Github - https://github.com/Simply-Awesome

## License

Distributed under the MIT License. 
