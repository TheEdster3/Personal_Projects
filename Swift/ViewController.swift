//
//  ViewController.swift
//  FlashCards
//
//  Created by Macbook on 6/9/16.
//  Copyright © 2016 Macbook. All rights reserved.
//

import Cocoa
import AppKit

class ViewController: NSViewController {
    //Data Structures
    //var temp_flashcard = FlashCard(left_card: "", right_card: "")
    var left_and_right_flashcards:[FlashCard] = []
    
    
    //Properties
    @IBOutlet var left_flash_card: NSTextView!
    @IBOutlet var right_flash_card: NSTextView!
    @IBOutlet weak var flashcard_count: NSButtonCell!
    
    //Passed Data
    var toPass: [FlashCard]!
    var passKey: String!
    
    
    override func viewDidLoad() {
        if(toPass != nil) {
            left_and_right_flashcards = toPass
        }
        flashcard_count.title = String(left_and_right_flashcards.count)
        
        super.viewDidLoad()
        
        
         //Used to fill the cards with fake values for testing purposes
        /*
        var k = 0
        while k != 10000
        {
            let temp_card = FlashCard(left_card: (String(k) + "a"), right_card: (String(k) + "b"))
            left_and_right_flashcards += [temp_card]
            
            k += 1
        }
        */

        // Do any additional setup after loading the view.
        
        left_flash_card.font = NSFont(name: "Verdana", size: 25)
        right_flash_card.font = NSFont(name: "Verdana", size: 25)
    }

    override var representedObject: AnyObject? {
        didSet {
        // Update the view, if already loaded.
        }
    }
    
    override func prepareForSegue(segue: NSStoryboardSegue, sender: AnyObject!) {
        if (segue.identifier == "toFlashCardTest") {
            //Checking identifier is crucial as there might be multiple
            // segues attached to same view
            let detailVC = segue.destinationController as! SecondViewController
            
            detailVC.toPass = left_and_right_flashcards
        }
    }
    
    //Actions
    @IBAction func saveCards(sender: NSButton) {
        
        //variables for easier understanding
        let temp_card = FlashCard(left_card: left_flash_card.string!, right_card: right_flash_card.string!)
        
        left_and_right_flashcards += [temp_card]
        
        flashcard_count.title = String(left_and_right_flashcards.count)
        
        //Should eventually save both cards as a pair and add them to a growing array of flash cards for a given profile
        
        //For saving things
        archive(passKey, archive: &left_and_right_flashcards)
    }
    
    @IBAction func resetCards(sender: NSButton) {
    } //Resets the non-repetition array
    
    func archive(key: String!, inout archive: [FlashCard])
    {
        let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
        
        let path: AnyObject = paths[0]
        
        let arrPath = path.stringByAppendingString("/" + passKey + ".plist")
        
        NSKeyedArchiver.archiveRootObject(left_and_right_flashcards, toFile: arrPath)
        print(passKey)
    } //Archives the flashcards for a given class
}

