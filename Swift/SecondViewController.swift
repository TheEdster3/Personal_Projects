//
//  SecondViewController.swift
//  FlashCards
//
//  Created by Macbook on 6/17/16.
//  Copyright © 2016 Macbook. All rights reserved.
//

import Foundation
import Cocoa
import AppKit

class SecondViewController: NSViewController {
    
    var toPass: [FlashCard]!
    var prevRollsPass: [Int]!
    var total_flashcards = 0
    var remaining_flashcards = 0
    //var left_and_right_flashcards:[(left_card:String, right_card: String)] = []
    var left_and_right_flashcards: [FlashCard]!
    var previous_rolls: [Int] = []
    var times_pressed = 0
    var diceRoll = 0
    
    @IBOutlet weak var test_card: NSTextFieldCell!
    @IBOutlet weak var flashcardCount: NSButton!
    @IBOutlet weak var progressBar: NSProgressIndicator!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        left_and_right_flashcards = toPass
        
        test_card.font = NSFont(name: "Verdana", size: 25)
        
        //Set total cards and the remaining left to go through
        if(left_and_right_flashcards != nil)
        {
            total_flashcards = left_and_right_flashcards.count
        }
        else {
            total_flashcards = 0
        }
        
        //Update flashcard count
        flashcardCount.title = String(remaining_flashcards) + " of " + String(total_flashcards * 2)
        
        //Update progress bar
        progressBar.minValue = Double(remaining_flashcards)
        progressBar.maxValue = Double(total_flashcards)
        
    }
    
    
    @IBAction func reset_cards(sender: NSButton) {
        remaining_flashcards = 0
        
        //Update Flashcard Count
        flashcardCount.title = String(remaining_flashcards) + " of " + String(total_flashcards * 2)
        
        for i in 0..<previous_rolls.count
        {
            previous_rolls[i] = i
        } //Reset the previous roll array
        
        times_pressed = 0
        progressBar.doubleValue = 0
        test_card.title = ""
        
    } //Allow the user to restart the testing process
    
    @IBAction func nextCard(sender: NSButton) {
        if (times_pressed != 2 * total_flashcards)
        {
            randCard()
            times_pressed += 1
            
            //Increment progress bar
            progressBar.incrementBy(0.5)
        } //If there are flashcards remaining
        else
        {
        } //dismiss view controller
    }
    
    func randCard()
    {
        var cards_left = false
        for i in 0..<left_and_right_flashcards.count
        {
            if(previous_rolls.count != left_and_right_flashcards.count)
            {
                previous_rolls += [i]
            } //Create an array the size of the number of flashcards
        } //Create an array to check against reusing flashcards
    
    if(left_and_right_flashcards.count >= 1)
    {
        if(times_pressed % 2 == 0)
        {
            //Determine the random cards
            diceRoll(&previous_rolls, left_and_right_flashcards: left_and_right_flashcards)
            
            //If it hit a card that hasn't been hit before
            if(diceRoll == previous_rolls[diceRoll])
            {
                previous_rolls[diceRoll] = -1
                cards_left = true
            } //if diceRoll isn't repeating
        } //If we're not on a new flashcard
    
    } //If there is at least one flashcard pair then randomly select one
    
    if(left_and_right_flashcards.count != 0)
    {
        //Update flashcard count
        remaining_flashcards += 1
        
        if(times_pressed % 2 == 0 && cards_left == true)
        {
            //Update active label
            test_card.title = left_and_right_flashcards[diceRoll].left_card
        }
        else
        {
            test_card.title = left_and_right_flashcards[diceRoll].right_card
        } //Display the back of the flashcard
        
        //Update flashcard count display
        flashcardCount.title = String(remaining_flashcards) + " of " + String(total_flashcards * 2)
    }
}

    func stuckCheck(inout j: Int, inout previous_rolls: [Int], inout diceRoll: Int)
    {
        if(j == 0)
        {
            for element in previous_rolls
            {
                if(element != -1)
                {
                    j = previous_rolls.count * 10
                    diceRoll = element
                    break
                } //If there are flashcards left try again
                else
                {
                    j = -1
                    break;
                } //If there are no flashcards left break and mark the outer loop to break
            }
        } //Check if all possibilities have been thrown
    }
    
    func diceRoll(inout previous_rolls: [Int], left_and_right_flashcards:[FlashCard])
    {
        diceRoll = Int(arc4random_uniform(UInt32(left_and_right_flashcards.count)))
        
        var j = previous_rolls.count * 10
        while diceRoll != previous_rolls[diceRoll]
        {
            diceRoll = Int(arc4random_uniform(UInt32(left_and_right_flashcards.count)))
            j -= 1
            
            stuckCheck(&j, previous_rolls: &previous_rolls, diceRoll: &diceRoll)
            if(j == -1) {
                break;
            } //Break if there are no flashcards left
        } //Change diceRoll until it isn't repeating
    }

}