class queue(object):
    def __init__(self, items = None):
        self.items = []

    def enqueue(self, item):
        self.items.append(item)

    def dequeue(self):
        if len(self.items) > 0:
            del(self.items[0])

    def front(self):
        if len(self.items) > 0:
            return self.items[0]
