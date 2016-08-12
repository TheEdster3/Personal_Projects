//
//  MainMenuViewController.swift
//  FlashCards
//
//  Created by Macbook on 6/19/16.
//  Copyright © 2016 Macbook. All rights reserved.
//

import Foundation
import AppKit
import Cocoa

class MainMenuViewController: NSViewController {
    
    //Flashcards to be passed and flashcard names
    var FlashcardClass: [FlashCard]!
    var saved_flashcard_names: [String] = []
    
    //Outlets
    @IBOutlet weak var flashcards_name: NSTextField!
    @IBOutlet weak var list_of_flashcard_names: NSPopUpButton!
    @IBOutlet weak var createButton: NSButton!
    @IBOutlet weak var testButton: NSButtonCell!
    
    @IBAction func saveName(sender: NSTextField) {
        
        if(flashcards_name.stringValue != "")
        {
            list_of_flashcard_names.addItemsWithTitles([flashcards_name.stringValue])
            
            list_of_flashcard_names.selectItemAtIndex(list_of_flashcard_names.itemArray.count - 1)
            
            saved_flashcard_names += [flashcards_name.stringValue]
            
            flashcards_name.stringValue = ""
        }
        
        loadKeys()
        checkCreateButtonState()
        
    } //Saves keys that are added for separation of flashcards into groups
    
    @IBAction func loadCreateScreen(sender: NSButton)
        {
    }
    
    @IBAction func loadTestScreen(sender: NSButton) {
        
    }
    
    @IBAction func deleteCards(sender: AnyObject) {
            //Find the path of the flashcards file
    if(list_of_flashcard_names.titleOfSelectedItem != nil)
        {
            
            deleteFile()
            
        if(list_of_flashcard_names.itemArray.count != 0 && saved_flashcard_names.count != 0)
            {
                //Remove the selected item in the list
                removeItem()
                
                let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
                let path: AnyObject = paths[0]
                let arrPath2 = path.stringByAppendingString("/keys.plist")
                
                NSKeyedArchiver.archiveRootObject(saved_flashcard_names, toFile: arrPath2)
            }
            
        }
        
        checkCreateButtonState()
    }
    
    override func viewDidLoad() {
        
        //Unarchives key file and puts flashcard groupings into saved_flashcard_names
        unloadKeys(&saved_flashcard_names)
        
        //Properly load the drop down menu
    list_of_flashcard_names.removeAllItems()
        addTitlesToDropdown()
        checkCreateButtonState()
        
    } //Upon loading
    
    override func prepareForSegue(segue: NSStoryboardSegue, sender: AnyObject!) {
        
        FlashcardClass = nil
        
        //unarchives the proper flashcards before switching
    if(list_of_flashcard_names.titleOfSelectedItem != nil)
            {
            let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
            let path: AnyObject = paths[0]
            let arrPath = path.stringByAppendingString("/" + (list_of_flashcard_names.titleOfSelectedItem!) + ".plist")
            
            if let tempArr: [FlashCard] = NSKeyedUnarchiver.unarchiveObjectWithFile(arrPath) as? [FlashCard] {
                FlashcardClass = tempArr
            }
            
            if (segue.identifier == "toFlashCardTest") {
                //Checking identifier is crucial as there might be multiple
                // segues attached to same view
                let detailVC = segue.destinationController as! SecondViewController
                
                detailVC.toPass = FlashcardClass
                
            }
            else if(segue.identifier == "toFlashCardCreate") {
                
                //Checking identifier is crucial as there might be multiple
                //segues attached to same view
                let detailVC = segue.destinationController as! ViewController
                
                detailVC.toPass = FlashcardClass
                detailVC.passKey = list_of_flashcard_names.titleOfSelectedItem!
                
                print(list_of_flashcard_names.titleOfSelectedItem!)
            }
        }
    }
    
    func loadKeys()
    {
        let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
        let path: AnyObject = paths[0]
        let arrPath = path.stringByAppendingString("/keys.plist")
        
        NSKeyedArchiver.archiveRootObject(saved_flashcard_names, toFile: arrPath)
    }
    
    func unloadKeys(inout names: [String])
    {
        let paths2 = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
        let path2: AnyObject = paths2[0]
        let arrPath2 = path2.stringByAppendingString("/keys.plist")
        
        if let tempArr2: [String] = NSKeyedUnarchiver.unarchiveObjectWithFile(arrPath2) as? [String] {
            names = tempArr2
        }
    } //Unload keys
    
    func deleteFile()
    {
            let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
            let path: AnyObject = paths[0]
            let arrPath = path.stringByAppendingString("/" + (list_of_flashcard_names.titleOfSelectedItem!) + ".plist")

            //Instantiate File Manager
            let fileManager = NSFileManager.defaultManager()

            //Remove item at path
            do {
            try fileManager.removeItemAtPath(arrPath)
            }
            catch let error as NSError {
            print("Ooops! Something went wrong: \(error)")
        }
    }

    func removeItem()
    {
        list_of_flashcard_names.removeItemAtIndex(list_of_flashcard_names.indexOfSelectedItem)
        
        saved_flashcard_names.removeAtIndex(list_of_flashcard_names.indexOfSelectedItem + 1)
    }
    
    func checkCreateButtonState()
    {
        if(list_of_flashcard_names.titleOfSelectedItem == nil)
        {
            createButton.enabled = false
        }
        else
        {
            createButton.enabled = true
        }
        if(list_of_flashcard_names.titleOfSelectedItem == nil)
        {
            testButton.enabled = false
        }
        else
        {
            testButton.enabled = true
        }
    } //Correctly disables buttons
    
    func unarchive(key: String!, inout archive: [FlashCard])
    {
        let paths = NSSearchPathForDirectoriesInDomains(NSSearchPathDirectory.DocumentDirectory,NSSearchPathDomainMask.AllDomainsMask, true)
        let path: AnyObject = paths[0]
        let arrPath = path.stringByAppendingString("/" + key + ".plist")
        
        if let tempArr: [FlashCard] = NSKeyedUnarchiver.unarchiveObjectWithFile(arrPath) as? [FlashCard] {
            archive = tempArr
        }

    } //unarchives the flashcards for a given class
    
    func addTitlesToDropdown()
    {
        for n in saved_flashcard_names
        {
            if(n != "")
            {
                list_of_flashcard_names.addItemWithTitle(n)
            }
        }
    } //Adds items to dropdown menu
    
}