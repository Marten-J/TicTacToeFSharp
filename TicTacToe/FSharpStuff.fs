//
// My F# Cheat Sheet:
// This is just a file with different F# operations
// to know how it works
//
module FSharpStuff

open System

type Rectangle = struct 
    val Length : float
    val Width : float

    new (length, width) =
        {Length = length; Width = width;}
end

let struct_stuff() =
    let area(shape: Rectangle) =
        shape.Length * shape.Width

    let rect = new Rectangle(5.0, 6.0)

    let rect_area = area rect

    printfn "Area: %.2f" rect_area

type Animal = class
    val Name : string
    val Height : float
    val Weight : float
    
    new (name, height, weight) =
        {Name = name; Height = height; Weight = weight;}

    member x.Run =
        printfn "%s Runs" x.Name
end

type Dog(name, height, weight) =
    inherit Animal(name, height, weight)

    member x.Bark =
        printfn "%s Barks" x.Name

let class_stuff() = 
    let spot = new Animal("Spot", 20.5, 40.5)
    spot.Run

    let bowser = new Dog("Bowser", 20.5, 40.5)
    bowser.Run
    bowser.Bark


let do_funcs() =
    let get_sum (x: int, y: int) : int = x + y
    printfn "5 + 7 = %i" (get_sum(5, 7))

    let rec factorial x =
        if x < 1 then 1
        else x * factorial (x - 1)
    printfn "Factorial 4 : %i" (factorial 4)

    let rand_list = [1;2;3]
    let rand_list2 = List.map (fun x -> x * 2) rand_list
    printfn "Double List : %A" rand_list2

    [5;6;7;8]
    |> List.filter (fun v -> (v % 2) = 0)
    |> List.map (fun x -> x * 2)
    |> printfn "Even Double : %A" 

    let mult_num x = x * 3
    let add_num y = y + 3
    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num
    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)

let string_stuff() =
    let str1 = "This is a random string"
    let str2 = @"I ifnore backslashes"
    let str3 = """ "I infore double quotes and backslashes" """
    let str4 = str1 + "" + str2
    printfn "Length :%i" (String.length str4)
    printfn "1st Word : %s" (str1.[0..3])

    let upeer_str = String.collect (fun c -> sprintf "%c, " c) "commas"
    printfn "Commas : %s" upeer_str
    
    printfn "Any upper : %b" (String.exists (fun c -> Char.IsUpper(c)) str1)

    printfn "Number: %b" (String.forall (fun c -> Char.IsDigit(c)) "1234")
    
    let string1 = String.init 10 (fun i -> i.ToString())
    printfn "Number : %s" string1

let loop_stuff() =
    let magic_num = "7"
    let mutable guess = ""
    while not (magic_num.Equals(guess)) do
        printf "Guess the Number : "
        guess <-  Console.ReadLine()

    for i = 1 to 10 do
        printfn "%i" i

    [1..10] |> List.iter (printfn "Num : %i")

    let sum = List.reduce (+) [1..10]
    printfn "Sum: %i" sum


let cond_Stuff() = 
    let age = 8

    if age < 5 then
        printfn "Preschool"
    elif age = 5 then
        printfn "Kindergarten"
    elif (age > 5) && (age <= 18) then
        let grade = age - 5
        printfn "Go to Grade %i" grade
    else
        printfn "Go to Collage"

    let gpa = 3.9
    let income = 15000
    printfn "Collage Grant : %b" ((gpa >= 3.8) || (income <= 12000))
    printfn "Not True : %b" (not true)

    let grade2: string =
        match age with
        | age when age <5 -> "Preschool"
        | 5 -> "Kindergarten"
        | age when ((age > 5) && (age <=18)) -> (age - 5).ToString()
        | _ -> "Collage"

    printfn "Grade2: %s" grade2


let list_stuff() =
    let list1 = [1;2;3;4]
    list1 |> List.iter (printfn "Num : %i")
    printfn "%A" list1

    let list2 = 5::6::7::[]
    printfn "%A" list2

    let list3 =  [1..5]
    let list4 = ['a'..'g']
    printfn "%A" list4

    let list5 = List.init 5 (fun i -> i * 2)
    printfn "%A" list5

    let list6 = [ for a in 1..5 do yield (a * a)]
    let list7 = [for a in 1..20 do if a % 2 = 0 then yield a]
    let list8 = [for a in 1..3 do yield! [ a .. a + 2]]
    printfn "%A" list8

    printfn "Length: %i" list8.Length
    printfn "Empty: %b" list8.IsEmpty
    printfn "Index 2: %c" (list4.Item(2))
    printfn "Head 2: %c" (list4.Head)
    printfn "Tail 2: %A" (list4.Tail)

    let list9 = list3 |> List.filter (fun x -> x % 2 = 0)
    let list10 = list9 |> List.map (fun x -> (x * x))
    printfn "Sorted : %A" (List.sort [5;4;3])

let do_math() =
    let number = 2
    printfn "Type : %A" (number.GetType())
    printfn "A Float : %.2f" (float number)
    printfn "A Float : %i" (int 3.14)


let hello() =
    printf "Enter your Name: "
    let name = Console.ReadLine()
    printf "padding %5s" name
    printfn "Hello %s" name

// hello()
do_funcs()
Console.ReadKey() |> ignore