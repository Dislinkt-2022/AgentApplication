FROM mcr.microsoft.com/mssql/server

ARG SA_PASSWORD
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=${SA_PASSWORD}

COPY ./Data/Init /

CMD [ "/bin/bash", "entrypoint.sh", "/opt/mssql/bin/sqlservr", "$SA_PASSWORD"]