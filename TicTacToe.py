# Задача крестики нолики реализованная на питоне
class TicTacToe:
    def __init__(self):
        self.board = [[' ' for _ in range(3)] for _ in range(3)]
        self.current_player = 'X'
    
    def print_board(self):
        print("\n  0   1   2")
        for i, row in enumerate(self.board):
            print(f"{i} {row[0]} | {row[1]} | {row[2]}")
            if i < 2:
                print("  ---------")
        print()
    
    def make_move(self, row, col):
        if 0 <= row < 3 and 0 <= col < 3 and self.board[row][col] == ' ':
            self.board[row][col] = self.current_player
            return True
        return False
    
    def check_winner(self):
        # Проверка строк
        for row in self.board:
            if row[0] == row[1] == row[2] != ' ':
                return row[0]
        
        # Проверка столбцов
        for col in range(3):
            if self.board[0][col] == self.board[1][col] == self.board[2][col] != ' ':
                return self.board[0][col]
        
        # Проверка диагоналей
        if self.board[0][0] == self.board[1][1] == self.board[2][2] != ' ':
            return self.board[0][0]
        if self.board[0][2] == self.board[1][1] == self.board[2][0] != ' ':
            return self.board[0][2]
        
        return None
    
    def is_board_full(self):
        for row in self.board:
            if ' ' in row:
                return False
        return True
    
    def switch_player(self):
        self.current_player = 'O' if self.current_player == 'X' else 'X'
    
    def play(self):
        print("Добро пожаловать в Крестики-нолики!")
        print("Вводите координаты в формате: строка столбец (например: 0 1)")
        
        while True:
            self.print_board()
            
            # Получаем ход от текущего игрока
            try:
                move = input(f"Игрок {self.current_player}, ваш ход: ").split()
                if len(move) != 2:
                    print("Введите две координаты через пробел!")
                    continue
                
                row, col = int(move[0]), int(move[1])
                
                if not self.make_move(row, col):
                    print("Неверный ход! Попробуйте снова.")
                    continue
                
            except (ValueError, IndexError):
                print("Введите корректные числа от 0 до 2!")
                continue
            
            # Проверяем победителя
            winner = self.check_winner()
            if winner:
                self.print_board()
                print(f"Поздравляем! Игрок {winner} победил!")
                break
            
            # Проверяем ничью
            if self.is_board_full():
                self.print_board()
                print("Ничья!")
                break
            
            # Переключаем игрока
            self.switch_player()

# Запуск игры
if __name__ == "__main__":
    game = TicTacToe()
    game.play()
