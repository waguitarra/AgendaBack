import schedule
import time
import subprocess

def restart_script():
    subprocess.call(["sudo", "systemctl", "restart", "supervisor"])
    subprocess.call(["python", __file__])

schedule.every().day.at("03:00").do(restart_script)

while True:
    schedule.run_pending()
    time.sleep(1)
