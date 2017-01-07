class node(object):
    def __init__(self, data = None, next = None):
        self.data = data
        self.next = next

    def get_data(self):
        return self.data

    def get_next(self):
        return self.next

    def set_next(self, next_node):
        self.next = next_node

class LinkedList(object):
    def __init__(self, head = None):
        self.head = head

    def get_head(self):
        return self.head
    
    def insert(self, data):
        new_node = node(data)
        new_node.set_next(self.head)
        self.head = new_node

    def delete(self, search_item):
        current = self.head
        found = False
        
        if current:
            if current.get_data() == search_item:
                found = True
                self.head = self.head.get_next()
            
            while current.get_next() and not found:
                if search_item == current.get_next().get_data():
                    found = True
                    current.set_next(current.get_next().get_next())
                else:
                    current = current.next
                
        if current == None and not found:
            print("Object not found")

    def size(self):
        current = self.head
        count = 0
        while current:
            count = count + 1
            current = current.next
        return count

    def find(self, search_item):
        current = self.head
        found = False
        while current and not found:
            if search_item == current.get_data():
                found = True
                print(current.get_data())
            else:
                current = current.next
        if current == None and not found:
            print("Object not found")
        
