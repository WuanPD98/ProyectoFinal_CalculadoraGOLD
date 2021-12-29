﻿'Generated by the GOLD Parser Builder

Option Explicit On
Option Strict Off

Imports System.IO
Imports System.Windows.Forms


Module MyParser
    Private Parser As New GOLD.Parser
    Public Root As GOLD.Reduction

    Private Enum SymbolIndex
        [Eof] = 0                                 ' (EOF)
        [Error] = 1                               ' (Error)
        [Whitespace] = 2                          ' Whitespace
        [Times] = 3                               ' '*'
        [Plus] = 4                                ' '+'
        [Numero] = 5                              ' NUMERO
        [E] = 6                                   ' <E>
        [F] = 7                                   ' <F>
        [T] = 8                                   ' <T>
    End Enum

    Private Enum ProductionIndex
        [E_Plus] = 0                              ' <E> ::= <E> '+' <T>
        [E] = 1                                   ' <E> ::= <T>
        [T_Times] = 2                             ' <T> ::= <T> '*' <F>
        [T] = 3                                   ' <T> ::= <F>
        [F_Numero] = 4                            ' <F> ::= NUMERO
    End Enum

    Public Program As Object     'You might derive a specific object

    Public Sub Setup()
        'This procedure can be called to load the parse tables. The class can
        'read tables using a BinaryReader.

        Parser.LoadTables(Path.Combine(Application.StartupPath, "Calculadora.egt"))
    End Sub

    Public Function Parse(ByVal Reader As TextReader) As Boolean
        'This procedure starts the GOLD Parser Engine and handles each of the
        'messages it returns. Each time a reduction is made, you can create new
        'custom object and reassign the .CurrentReduction property. Otherwise, 
        'the system will use the Reduction object that was returned.
        '
        'The resulting tree will be a pure representation of the language 
        'and will be ready to implement.

        Dim Response As GOLD.ParseMessage
        Dim Done as Boolean                  'Controls when we leave the loop
        Dim Accepted As Boolean = False      'Was the parse successful?

        Accepted = False    'Unless the program is accepted by the parser

        Parser.Open(Reader)
        Parser.TrimReductions = False  'Please read about this feature before enabling  

        Done = False
        Do Until Done
            Response = Parser.Parse()

            Select Case Response
                Case GOLD.ParseMessage.LexicalError
                    'Cannot recognize token
                    Done = True

                Case GOLD.ParseMessage.SyntaxError
                    'Expecting a different token
                    Done = True

                Case GOLD.ParseMessage.Reduction
                    'Create a customized object to store the reduction
                    '.CurrentReduction = CreateNewObject(Parser.CurrentReduction)

                Case GOLD.ParseMessage.Accept
                    'Accepted!
                    'Program = Parser.CurrentReduction  'The root node! 
                    Root = Parser.CurrentReduction
                    Done = True
                    Accepted = True

                Case GOLD.ParseMessage.TokenRead
                    'You don't have to do anything here.

                Case GOLD.ParseMessage.InternalError
                    'INTERNAL ERROR! Something is horribly wrong.
                    Done = True

                Case GOLD.ParseMessage.NotLoadedError
                    'This error occurs if the CGT was not loaded.                   
                    Done = True

                Case GOLD.ParseMessage.GroupError
                    'COMMENT ERROR! Unexpected end of file
                    Done = True
            End Select
        Loop

        Return Accepted
    End Function

    Private Function CreateNewObject(Reduction as GOLD.Reduction) As Object
        Dim Result As Object = Nothing

        With Reduction
            Select Case .Parent.TableIndex
                Case ProductionIndex.E_Plus
                    ' <E> ::= <E> '+' <T> 

                Case ProductionIndex.E
                    ' <E> ::= <T> 

                Case ProductionIndex.T_Times
                    ' <T> ::= <T> '*' <F> 

                Case ProductionIndex.T
                    ' <T> ::= <F> 

                Case ProductionIndex.F_Numero
                    ' <F> ::= NUMERO 

            End Select
        End With

        Return Result
    End Function
End Module
