class stack(object):
    def __init__(self, items = None):
        self.items = []

    def push(self, item):
        self.items.append(item)

    def pop(self):
        if len(self.items) > 0:
            del(self.items[len(self.items) - 1])
        else:
            print("Stack Empty")

    def peek(self):
        if len(self.items) > 0:
            return self.items[len(self.items) - 1]
        else:
            print("Stack Empty")

    def size(self):
        return len(self.items)

    def peek_and_pop(self):
        if len(self.items) > 0:
            item = self.items[len(self.items) - 1]
            del(self.items[len(self.items) - 1])
            return item
        else:
            print("Stack Empty")
