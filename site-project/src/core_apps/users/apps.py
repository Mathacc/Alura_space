from django.apps import AppConfig
from django.utils.translation import gettext_lazy as _
#gettext_lazy is used as a internationalization for django

class UsersConfig(AppConfig):
    default_auto_field = "django.db.models.BigAutoField"
    name = "core_apps.users"
    verbose_name = _("Users") #create a human readable name in singular
