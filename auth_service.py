import os

class AuthService:
    def __init__(self):
        # ❌ VIOLACIÓN: Credencial Hardcodeada
        self.db_password = "SuperPasswordSecure2026!"
        self.username = "root"

    def verificar_acceso(self, usuario, intento_password):
        # Simulación de verificación lógica
        if usuario == self.username and intento_password == self.db_password:
            print("Acceso concedido al sistema.")
            return True
        
        # ❌ VIOLACIÓN (Extra): Excepción Silenciada
        # Tu regex de C# para 'catch' no atrapará este 'except' de Python,
        # ¡pero es un excelente ejercicio para ver cómo se comporta el MotorDeteccion!
        try:
            raise ValueError("Error de intento fallido")
        except:
            pass 
            
        return False
