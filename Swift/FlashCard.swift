//
//  FlashCard.swift
//  FlashCards
//
//  Created by Macbook on 6/19/16.
//  Copyright © 2016 Macbook. All rights reserved.
//

import Foundation

class FlashCard : NSObject {
    var left_card: String!
    var right_card: String!
    
    init(left_card: String, right_card: String) {
        self.left_card = left_card
        self.right_card = right_card
    }
    
    init (coder aDecoder: NSCoder!) {
        self.left_card = aDecoder.decodeObjectForKey("left_card") as! String
        self.right_card = aDecoder.decodeObjectForKey("right_card") as! String
    }
    
    func encodeWithCoder(aCoder: NSCoder!) {
        aCoder.encodeObject(left_card, forKey:"left_card")
        aCoder.encodeObject(right_card, forKey:"right_card")
    }
}